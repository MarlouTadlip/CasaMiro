using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using CasaMiro.Models;

namespace CasaMiro
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        // Use static to share state across instances (temporary for debugging)
        private static User? _currentUser;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_currentUser == null)
            {
                Console.WriteLine($"CustomAuthProvider: GetAuthenticationStateAsync - No user set (Thread: {Thread.CurrentThread.ManagedThreadId})");
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _currentUser.Email),
                new Claim(ClaimTypes.Role, _currentUser.Role ?? "User"),
                new Claim("FullName", _currentUser.FullName ?? "User")
            }, "SimpleAuth");

            Console.WriteLine($"CustomAuthProvider: GetAuthenticationStateAsync - User: {_currentUser.Email}, Role: {_currentUser.Role} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            var principal = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(principal));
        }

        public async Task LoginAsync(User user)
        {
            if (user == null)
            {
                Console.WriteLine("CustomAuthProvider: LoginAsync - Null user provided");
                throw new ArgumentNullException(nameof(user));
            }

            _currentUser = user;
            Console.WriteLine($"CustomAuthProvider: LoginAsync - Set user: {user.Email}, Role: {user.Role}, FullName: {user.FullName} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            await Task.CompletedTask;
        }

        public async Task LogoutAsync()
        {
            Console.WriteLine($"CustomAuthProvider: LogoutAsync - Clearing user: {_currentUser?.Email} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            await Task.CompletedTask;
        }

        public User? GetCurrentUser()
        {
            Console.WriteLine($"CustomAuthProvider: GetCurrentUser - User is: {(_currentUser != null ? _currentUser.Email : "null")} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            return _currentUser;
        }
    }
}