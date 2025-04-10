using CasaMiro.Data;
using CasaMiro.Models;
using Microsoft.EntityFrameworkCore;

public class AuthenticationService
{
    private readonly ApplicationDbContext _context;

    public AuthenticationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.Password != password) return null;

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during login: {ex.Message}");
            throw; // Re-throw exception for logging or higher-level handling
        }
    }

    public async Task LogoutAsync()
    {
        try
        {
            // Implement logout logic here if necessary
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during logout: {ex.Message}");
            throw; // Re-throw exception for logging or higher-level handling
        }
    }

    public async Task<User?> GetUserAsync()
    {
        // Implement logic to retrieve the current user based on authentication state
        // For demonstration purposes, this is simplified
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == "example@example.com");
    }
}
