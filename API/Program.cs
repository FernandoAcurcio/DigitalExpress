using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        /***
         * API- receives http requests and responding to them
         * -> Controllers
         * 
         * Infrastructure - comunicate with the database, send queries and receive data from database
         * -> Repository
         * -> DbContext
         * -> Services
         * -> Comunicate with the database
         * 
         * Core - contain business intities
         * -> Entities
         * -> Interfaces
         */

        // create a webserver
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddApplicationServices(builder.Configuration);

        var app = builder.Build();

        // any error handling needs to go here
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseStatusCodePagesWithReExecute("/errors/{0}");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();

        // if doesn't exist migrate our database
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<StoreContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();

        // will try to migrate our database
        try
        {
            await context.Database.MigrateAsync();
            await StoreContextSeed.SeedAsync(context);
        }
        catch (Exception ex)
        {
            // catch any exception that can occur 
            logger.LogError(ex, "An error occured during migration");
        }

        app.Run();
    }
}

internal record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
