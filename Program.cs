using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GestaoeventosDatabaseSettings>
    (builder.Configuration.GetSection("MongoDBDatabase"));

builder.Services.AddSingleton<PessoaServices>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();