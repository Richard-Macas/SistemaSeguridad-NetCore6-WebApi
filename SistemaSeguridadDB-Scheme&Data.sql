USE [SistemaSeguridadDB]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPortal] [int] NULL,
	[Empresa] [varchar](50) NOT NULL,
	[CorreoAdministrador] [varchar](100) NULL,
	[TelefonoAdministrador] [varchar](15) NULL,
	[Dominio] [varchar](200) NOT NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaSistema]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaSistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSistema] [int] NULL,
	[IdEmpresa] [int] NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_EMPRESASISTEMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PERFIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilSistema]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilSistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSistema] [int] NULL,
	[IdPerfil] [int] NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_PERFILSISTEMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portal]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Responsable] [varchar](200) NOT NULL,
	[Dominio] [varchar](200) NOT NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_PORTAL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recurso]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nivel] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[IdPadre] [int] NULL,
	[URLPath] [varchar](max) NOT NULL,
	[Icono] [varchar](50) NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_RECURSO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecursoPerfil]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecursoPerfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRecurso] [int] NULL,
	[IdPerfil] [int] NULL,
	[IdRol] [int] NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_RECURSOPERFIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Create] [bit] NULL,
	[Read] [bit] NULL,
	[Update] [bit] NULL,
	[Delete] [bit] NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sistema]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Dominio] [varchar](255) NOT NULL,
	[Subdominio] [varchar](255) NULL,
	[EstaHabilitado] [bit] NULL,
 CONSTRAINT [PK_SISTEMA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SistemaRecurso]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SistemaRecurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSistema] [int] NULL,
	[IdRecurso] [int] NULL,
 CONSTRAINT [PK_SISTEMARECURSO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 30/7/2022 18:26:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdPerfil] [int] NULL,
 CONSTRAINT [PK_USUARIOPERFIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (1, N'SuperAdmin')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (2, N'AdminCI')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (3, N'AdminGD')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (4, N'AdminVA')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (5, N'UsersCI')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (6, N'UsersGD')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (7, N'UsersVA')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[PerfilSistema] ON 

INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (1, 1, 1, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (2, 1, 2, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (3, 1, 5, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (4, 2, 3, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (5, 2, 6, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (6, 3, 4, 1)
INSERT [dbo].[PerfilSistema] ([Id], [IdSistema], [IdPerfil], [EstaHabilitado]) VALUES (7, 3, 7, 1)
SET IDENTITY_INSERT [dbo].[PerfilSistema] OFF
GO
SET IDENTITY_INSERT [dbo].[Recurso] ON 

INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (2, 0, N'Cotizaciones', NULL, N'/', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (3, 1, N'Nueva Solicitud', 2, N'/Nueva', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (4, 1, N'Historial de solicitudes', 2, N'/Historial', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (5, 0, N'Compras', NULL, N'/', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (7, 1, N'Nueva Solicitud', 5, N'/Nueva', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (8, 1, N'Generar Orden', 5, N'/Orden', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (9, 0, N'Nuevo Documento', NULL, N'/Nuevo', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (10, 0, N'Mis Documentos', NULL, N'/MisDocumentos', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (11, 0, N'Documentos Publicados', NULL, N'/Publicados', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (12, 0, N'Gestion de Documentos', NULL, N'/', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (13, 1, N'Revisión', 12, N'/Revision', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (16, 1, N'Aprobación', 12, N'/Aprobacion', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (17, 0, N'Mis Solicitudes', 0, N'/', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (18, 1, N'Nueva Solicitud', 17, N'/Nueva', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (19, 1, N'Solicitudes Anteriores', NULL, N'/Historial', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (20, 0, N'Revisar Solicitudes', NULL, N'/Revisar', NULL, 1)
INSERT [dbo].[Recurso] ([Id], [Nivel], [Descripcion], [IdPadre], [URLPath], [Icono], [EstaHabilitado]) VALUES (21, 0, N'Planificar Calendario', NULL, N'/Calendario', NULL, 1)
SET IDENTITY_INSERT [dbo].[Recurso] OFF
GO
SET IDENTITY_INSERT [dbo].[RecursoPerfil] ON 

INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (1, 2, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (2, 2, 2, 2, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (3, 2, 5, 5, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (4, 5, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (5, 5, 2, 2, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (6, 5, 5, 5, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (7, 9, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (8, 10, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (9, 11, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (10, 12, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (11, 9, 3, 3, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (12, 10, 3, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (13, 11, 3, 5, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (14, 12, 3, 2, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (15, 9, 6, 5, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (16, 10, 6, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (17, 11, 6, 5, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (18, 17, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (19, 20, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (20, 21, 1, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (21, 17, 4, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (22, 20, 4, 7, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (23, 21, 4, 1, 1)
INSERT [dbo].[RecursoPerfil] ([Id], [IdRecurso], [IdPerfil], [IdRol], [EstaHabilitado]) VALUES (24, 17, 7, 1, 1)
SET IDENTITY_INSERT [dbo].[RecursoPerfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (2, 1, 1, 1, 0)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (3, 1, 1, 0, 0)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (4, 1, 0, 0, 0)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (5, 0, 1, 0, 0)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (6, 0, 0, 1, 0)
INSERT [dbo].[Rol] ([Id], [Create], [Read], [Update], [Delete]) VALUES (7, 0, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Sistema] ON 

INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (1, N'Compras Internas', N'/SistemaInterno', N'/ComprasInternas', 1)
INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (2, N'Gestor Documental', N'/SistemaInterno', N'/GestorDocumental', 1)
INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (3, N'Vacaciones', N'/SistemaInterno', N'/Vacaciones', 1)
INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (1002, N'Ejmeplo Sistema', N'string', N'string', 1)
INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (1003, N'string', N'string', N'string', 1)
INSERT [dbo].[Sistema] ([Id], [Nombre], [Dominio], [Subdominio], [EstaHabilitado]) VALUES (1004, N'string', N'string', N'string', 1)
SET IDENTITY_INSERT [dbo].[Sistema] OFF
GO
SET IDENTITY_INSERT [dbo].[SistemaRecurso] ON 

INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (1, 1, 2)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (2, 1, 5)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (3, 2, 9)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (4, 2, 10)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (5, 2, 11)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (6, 2, 12)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (7, 3, 17)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (8, 3, 20)
INSERT [dbo].[SistemaRecurso] ([Id], [IdSistema], [IdRecurso]) VALUES (9, 3, 21)
SET IDENTITY_INSERT [dbo].[SistemaRecurso] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Username], [Password]) VALUES (2, N'rmacasna', N'rmacasna')
INSERT [dbo].[Usuario] ([Id], [Username], [Password]) VALUES (3, N'pperez', N'pperez')
INSERT [dbo].[Usuario] ([Id], [Username], [Password]) VALUES (4, N'jtorres', N'jtorres')
INSERT [dbo].[Usuario] ([Id], [Username], [Password]) VALUES (5, N'fgomez', N'fgomez')
INSERT [dbo].[Usuario] ([Id], [Username], [Password]) VALUES (6, N'nmorales', N'nmorales')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioPerfil] ON 

INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (1, 2, 1)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (2, 3, 2)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (3, 4, 3)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (4, 5, 4)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (5, 6, 5)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (6, 6, 6)
INSERT [dbo].[UsuarioPerfil] ([Id], [IdUsuario], [IdPerfil]) VALUES (7, 6, 7)
SET IDENTITY_INSERT [dbo].[UsuarioPerfil] OFF
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESA_PORTAL_EM_PORTAL] FOREIGN KEY([IdPortal])
REFERENCES [dbo].[Portal] ([Id])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_EMPRESA_PORTAL_EM_PORTAL]
GO
ALTER TABLE [dbo].[EmpresaSistema]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESAS_EMPRESA_E_EMPRESA] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresa] ([Id])
GO
ALTER TABLE [dbo].[EmpresaSistema] CHECK CONSTRAINT [FK_EMPRESAS_EMPRESA_E_EMPRESA]
GO
ALTER TABLE [dbo].[EmpresaSistema]  WITH CHECK ADD  CONSTRAINT [FK_EMPRESAS_SISTEMA_E_SISTEMA] FOREIGN KEY([IdSistema])
REFERENCES [dbo].[Sistema] ([Id])
GO
ALTER TABLE [dbo].[EmpresaSistema] CHECK CONSTRAINT [FK_EMPRESAS_SISTEMA_E_SISTEMA]
GO
ALTER TABLE [dbo].[PerfilSistema]  WITH CHECK ADD  CONSTRAINT [FK_PERFILSI_PERFIL_PE_PERFIL] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[PerfilSistema] CHECK CONSTRAINT [FK_PERFILSI_PERFIL_PE_PERFIL]
GO
ALTER TABLE [dbo].[PerfilSistema]  WITH CHECK ADD  CONSTRAINT [FK_PERFILSI_SISTEMA_P_SISTEMA] FOREIGN KEY([IdSistema])
REFERENCES [dbo].[Sistema] ([Id])
GO
ALTER TABLE [dbo].[PerfilSistema] CHECK CONSTRAINT [FK_PERFILSI_SISTEMA_P_SISTEMA]
GO
ALTER TABLE [dbo].[RecursoPerfil]  WITH CHECK ADD  CONSTRAINT [FK_RECURSOP_PERFIL_RE_PERFIL] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[RecursoPerfil] CHECK CONSTRAINT [FK_RECURSOP_PERFIL_RE_PERFIL]
GO
ALTER TABLE [dbo].[RecursoPerfil]  WITH CHECK ADD  CONSTRAINT [FK_RECURSOP_RECURSO_R_RECURSO] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recurso] ([Id])
GO
ALTER TABLE [dbo].[RecursoPerfil] CHECK CONSTRAINT [FK_RECURSOP_RECURSO_R_RECURSO]
GO
ALTER TABLE [dbo].[RecursoPerfil]  WITH CHECK ADD  CONSTRAINT [FK_RECURSOP_ROL_RECUR_ROL] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[RecursoPerfil] CHECK CONSTRAINT [FK_RECURSOP_ROL_RECUR_ROL]
GO
ALTER TABLE [dbo].[SistemaRecurso]  WITH CHECK ADD  CONSTRAINT [FK_SISTEMAR_RECURSO_S_RECURSO] FOREIGN KEY([IdRecurso])
REFERENCES [dbo].[Recurso] ([Id])
GO
ALTER TABLE [dbo].[SistemaRecurso] CHECK CONSTRAINT [FK_SISTEMAR_RECURSO_S_RECURSO]
GO
ALTER TABLE [dbo].[SistemaRecurso]  WITH CHECK ADD  CONSTRAINT [FK_SISTEMAR_SISTEMA_S_SISTEMA] FOREIGN KEY([IdSistema])
REFERENCES [dbo].[Sistema] ([Id])
GO
ALTER TABLE [dbo].[SistemaRecurso] CHECK CONSTRAINT [FK_SISTEMAR_SISTEMA_S_SISTEMA]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOP_PERFIL_US_PERFIL] FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_USUARIOP_PERFIL_US_PERFIL]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOP_USUARIOPE_USUARIO] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_USUARIOP_USUARIOPE_USUARIO]
GO
