using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

public class CustomAuthStateProvider : RevalidatingServerAuthenticationStateProvider
{
    private readonly PersistentComponentState _persistence;
    private readonly ILogger<CustomAuthStateProvider> _logger;

    public CustomAuthStateProvider(
        ILoggerFactory loggerFactory,
        PersistentComponentState persistence)
        : base(loggerFactory)
    {
        _persistence = persistence;
        _logger = loggerFactory.CreateLogger<CustomAuthStateProvider>();
    }

    // Required implementation for revalidation
    protected override async Task<bool> ValidateAuthenticationStateAsync(
        AuthenticationState authenticationState,
        CancellationToken cancellationToken)
    {
        // Implement your validation logic here
        return await Task.FromResult(true); // Temporary placeholder
    }

    protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);

    public async Task SetUserAuthentication(ClaimsIdentity identity)
    {
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}
