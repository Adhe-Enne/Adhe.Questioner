using Questioner.Data;
using Questioner.Repository;
using Questioner.Business;
using Core.SharedServices;
using Core.Framework.StarUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Servicios Custom
builder.Services.AddSwaggerWithJwt("Questioner.Api", "v1");
builder.Services.AddMySqlContext(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddSharedServices();
builder.Services.AddServicesBusiness();
builder.Services.AddAuthConfig(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidators();

var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigin") ?? "AllowedOrigin";
var withOrigins = builder.Configuration.GetSection("WithOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCorsConfiguration(allowedOrigin, withOrigins);
#endregion

var app = builder.Build();

#region App Configuration Custom
app.AddMiddleWareConfiguration();
#endregion

app.UseHttpsRedirection();
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
