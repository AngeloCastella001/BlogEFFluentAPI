using Api.Helpers;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
namespace Api.ExtensionMethods;
public static class ServiceExtensions
{

    public static async Task ConfigurarMigraciones(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        try
        {
            var context = services.GetRequiredService<BlogContext>();
            await context.Database.MigrateAsync();
            await BlogContextSeed.SeedAsync(context, loggerFactory);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "Ocurrió un error durante la migración");
        }
    }


}
