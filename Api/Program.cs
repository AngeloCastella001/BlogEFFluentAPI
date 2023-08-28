using Api;
using Api.ExtensionMethods;
using Core.Interfaces;
using Infraestructura;
using Infraestructura.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("BlogConnection"),
                    x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "blog")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}
);

var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/

await app.ConfigurarMigraciones();

app.ConfigureApi();

app.Run();
