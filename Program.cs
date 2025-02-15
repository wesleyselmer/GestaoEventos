using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GestaoeventosDatabaseSettings>
    (builder.Configuration.GetSection("MongoDBDatabase"));

builder.Services.AddSingleton<PessoaServices>();
builder.Services.AddSingleton<CampoServices>();
builder.Services.AddSingleton<EventoServices>();
builder.Services.AddSingleton<FamiliaServices>();
builder.Services.AddSingleton<HotelServices>();
builder.Services.AddSingleton<InfoObreiroServices>();
builder.Services.AddSingleton<QuartoServices>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();