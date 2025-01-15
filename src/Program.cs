using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
    });
}

builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext(
        "mongodb+srv://wesleyselmer:cH4v3s!99o@gestaoeventos.arheu.mongodb.net/?retryWrites=true&w=majority&appName=GestaoEventos", 
        "GestaoEventos"
        )
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    });
}

app.MapGet("/", () => "Hello World!");
app.Run();