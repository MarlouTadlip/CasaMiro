using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CasaMiro.Services
{
    public class SimpleAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly CustomAuthenticationStateProvider _authStateProvider;

        public SimpleAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            CustomAuthenticationStateProvider authStateProvider)
            : base(options, logger, encoder, clock)
        {
            _authStateProvider = authStateProvider;
            Logger.LogInformation($"SimpleAuthHandler: Initialized with provider instance {_authStateProvider.GetHashCode()}");
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Logger.LogInformation($"SimpleAuthHandler: Authenticating for {Request.Path} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated == true)
            {
                Logger.LogInformation($"SimpleAuthHandler: Authenticated user {user.Identity.Name}, Role: {user.FindFirst(ClaimTypes.Role)?.Value}");
                var ticket = new AuthenticationTicket(user, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }

            Logger.LogInformation($"SimpleAuthHandler: No authenticated user for {Request.Path}");
            return AuthenticateResult.NoResult();
        }
    }
}