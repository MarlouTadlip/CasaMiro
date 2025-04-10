using CasaMiro.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ApplicationDbContext _context;

    public CustomAuthenticationStateProvider(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            // Example: Retrieve user from database or session (replace with your logic)
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == "example@example.com");

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role ?? "User")
                };

                var identity = new ClaimsIdentity(claims, "CustomAuthScheme");
                var principal = new ClaimsPrincipal(identity);

                return new AuthenticationState(principal);
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting authentication state: {ex.Message}");
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }

    public void NotifyUserAuthentication(string email)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email)
        }, "CustomAuthScheme"));

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
    }

    public void NotifyUserLogout()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }
}
