using SistemaSeguridad.API;

var builder = WebApplication.CreateBuilder(args);

// Instanciar Startup
var startup = new Startup(builder.Configuration);

// Set ConfigureServices
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Set Configure
startup.Configure(app, app.Environment);

app.Run();
