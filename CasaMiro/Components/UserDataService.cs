using CasaMiro.Data;
using CasaMiro.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaMiro.Services
{
    public class UserDataService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public UserDataService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using var context = await _dbFactory.CreateDbContextAsync();
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }


        // Add methods for balance, requests, etc.
    }
}