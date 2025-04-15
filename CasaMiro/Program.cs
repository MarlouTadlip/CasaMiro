using CasaMiro.Components;
using CasaMiro.Data;
using CasaMiro.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CasaMiro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enable detailed Blazor circuit errors
            builder.Services.Configure<CircuitOptions>(options =>
            {
                options.DetailedErrors = true;
            });

            // Add services
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient();

            // Database
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

            // Authentication services
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<UserDataService>();

            // Authentication and Authorization
            builder.Services.AddAuthentication("SimpleAuth")
                .AddScheme<AuthenticationSchemeOptions, SimpleAuthenticationHandler>("SimpleAuth", null);
            builder.Services.AddAuthorization();

            // Circuit retention
            builder.Services.AddServerSideBlazor(options =>
            {
                options.DetailedErrors = true;
                options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(5);
            });

            // Logging
            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.AddDebug();
            });

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();

            // Blazor endpoints
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Debug endpoint
            app.MapGet("/debug-auth", async (CustomAuthenticationStateProvider authProvider) =>
            {
                var state = await authProvider.GetAuthenticationStateAsync();
                var user = state.User;
                if (user.Identity.IsAuthenticated)
                {
                    var claims = user.Claims.Select(c => $"{c.Type}: {c.Value}").ToList();
                    return Results.Ok(new
                    {
                        Authenticated = true,
                        Name = user.Identity.Name,
                        Roles = user.FindAll(ClaimTypes.Role).Select(c => c.Value),
                        Claims = claims
                    });
                }
                return Results.Ok(new { Authenticated = false });
            });

            app.Run();
        }
    }
}