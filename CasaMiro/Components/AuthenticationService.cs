using CasaMiro.Data;
using CasaMiro.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaMiro
{
    public class AuthenticationService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
        private readonly CustomAuthenticationStateProvider _authStateProvider;

        public AuthenticationService(
            IDbContextFactory<ApplicationDbContext> dbFactory,
            CustomAuthenticationStateProvider authStateProvider)
        {
            _dbFactory = dbFactory;
            _authStateProvider = authStateProvider;
            Console.WriteLine($"AuthService: Initialized with provider instance {authStateProvider.GetHashCode()}");
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            Console.WriteLine($"AuthService: Login attempt for {email}");
            using var context = await _dbFactory.CreateDbContextAsync();
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"AuthService: Found user - Email: {user.Email}, Role: {user.Role}, FullName: {user.FullName}");
                await _authStateProvider.LoginAsync(user);
                Console.WriteLine($"AuthService: LoginAsync called for {user.Email}");
                var currentUser = _authStateProvider.GetCurrentUser();
                Console.WriteLine($"AuthService: Post-login state - User: {(currentUser != null ? currentUser.Email : "null")}");
            }
            else
            {
                Console.WriteLine($"AuthService: No user found for {email} or incorrect password");
            }

            return user;
        }
    }
}