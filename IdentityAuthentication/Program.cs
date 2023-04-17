using IdentityAuthentication.Crosscutting;
using IdentityAuthentication.Crosscutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddContext(builder.Configuration);
builder.Services.AddPasswordConfig();
builder.Services.AddDependencyInjection();
builder.Services.AddAuthenticationConfig(builder.Configuration);
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.MapControllers();
app.Run();
