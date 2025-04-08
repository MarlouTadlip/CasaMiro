using CasaMiro.Data;
using CasaMiro.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
public class AuthenticationService
{
    private readonly ApplicationDbContext _context;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthenticationService(
        ApplicationDbContext context,
        AuthenticationStateProvider authStateProvider)
    {
        _context = context;
        _authStateProvider = authStateProvider;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || user.Password != password) return null;

        // Update authentication state
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role ?? "User")
        };
        var identity = new ClaimsIdentity(claims, "Cookies");
        await ((CustomAuthStateProvider)_authStateProvider).SetUserAuthentication(identity);

        return user;
    }
}


