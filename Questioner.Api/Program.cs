using Core.Framework.StartUp;
using Questioner.Data;
using Questioner.Repository;
using Questioner.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerWithJwt("Questioner.Api", "v1");

//inyectar dependencias
builder.Services.AddMySqlContext(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddServicesBusiness();

builder.Services.AddAuthConfig(builder.Configuration);

var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigin") ?? "AllowedOrigin";
var withOrigins = builder.Configuration.GetSection("WithOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCorsConfiguration(allowedOrigin, withOrigins);

var app = builder.Build();

app.UseCors(allowedOrigin);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
