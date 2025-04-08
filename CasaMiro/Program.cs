using CasaMiro.Components;
using CasaMiro.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;

namespace CasaMiro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enable detailed Blazor circuit errors (for debugging)
            builder.Services.Configure<CircuitOptions>(options =>
            {
                options.DetailedErrors = true;
            });

            // Add services to the container
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents(); // .NET 8's new Blazor Server

            // Database (ensure connection string is in appsettings.json)
            
            builder.Services.AddHttpContextAccessor();

            // Authentication (Cookie-based)
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = "/login"; // Ensure this route exists
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.SlidingExpiration = true; // Recommended
                });
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddCascadingAuthenticationState();
            var app = builder.Build();

            // Middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error"); // Production error handling
                app.UseHsts(); // HTTP Strict Transport Security
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication(); // Must come before UseAuthorization
            app.UseAuthorization();
            app.UseAntiforgery();

            // Blazor endpoints
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run();
        }
    }
}