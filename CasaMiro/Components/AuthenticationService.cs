using CasaMiro.Data; // Adjust namespace based on your project structure
using CasaMiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

public class AuthenticationService
{
    private readonly ApplicationDbContext _context;

    public AuthenticationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        Debug.WriteLine($"Attempting to log in with email: {email}");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return null; // User not found
        }

        if (user.Password == password)
        {
            return user; // Authentication successful
        }

        return null; // Invalid password
    }
}
