using MediatR;
using SistemaSeguridad.Domain.IRepositories;
using SistemaSeguridad.Entities.Auth;
using SistemaSeguridad.Entities.Response;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using SistemaSeguridad.Entities.Mapper;
using dto = SistemaSeguridad.Entities.Dtos;

namespace SistemaSeguridad.Domain.Features.Login.Queries.GetByExpression
{
    public class GetLoginTokenByExpressionQuery : LoginResponse, IRequest<ResponseData<TokenResponse>>
    {
    }

    public class GetLoginTokenByExpressionQueryHandler : IRequestHandler<GetLoginTokenByExpressionQuery, ResponseData<TokenResponse>>
    {
        private readonly IRepositorioUsuario _repository;
        private readonly IConfiguration _configuration;

        public GetLoginTokenByExpressionQueryHandler(IRepositorioUsuario repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<ResponseData<TokenResponse>> Handle(GetLoginTokenByExpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Validar que el usuario exista con las credenciales
                var usuario = await _repository.Get(x => x.Username.Equals(request.Username) && x.Password.Equals(request.Password));

                if (usuario == null)
                    return new ResponseData<TokenResponse>(true, $"No existen el usuario en la base de datos", null);

                // Mapeo de dal a dto
                var usuarioDto = new MapperUsuario().MapUsuario(usuario);

                // Se genera el token de acceso
                var tokenResponse = GetTokenResponseJwt(usuarioDto);

                // En caso de que se produzca un error en generar el token
                if (tokenResponse == null)
                    return new ResponseData<TokenResponse>(false, $"Error GUBEQ_01. Se produjo un error al generar el token de acceso", null);

                return new ResponseData<TokenResponse>(true, $"", tokenResponse);
            }
            catch (Exception ex)
            {
                return new ResponseData<TokenResponse>(false, $"Error GUBEQ_02. {ex.Message}", null);
            }
        }


        #region Métodos Privados
        private TokenResponse GetTokenResponseJwt(dto.Usuario usuario)
        {
            try
            {

                // Crear los claims
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sid, usuario.Id.ToString()),
                    new Claim("username", usuario.Username),
                };

                // Añadir perfiles
                foreach (var perfil in usuario.UsuarioPerfils)
                {
                    claims.Add(new Claim(ClaimTypes.Role, perfil.IdPerfilNavigation.Nombre));
                }

                // Generamos el token
                var token = JwtHelper.GetJwtToken(
                    usuario.Username,
                    _configuration["Jwt:SigningKey"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    TimeSpan.FromMinutes(double.Parse(_configuration["Jwt:TokenTimeoutMinutes"])),
                    claims.ToArray());

                return new TokenResponse()
                {
                    access_token = new JwtSecurityTokenHandler().WriteToken(token),
                    token_type = "Bearer",
                    expires_in = token.ValidTo,
                };

            }
            catch (Exception)
            {
                throw new NullReferenceException("Ha ocurrido un error al general el token de acceso");
            }
        }
        #endregion
    }
}
