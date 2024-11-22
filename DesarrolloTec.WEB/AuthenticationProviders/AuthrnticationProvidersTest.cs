using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;


namespace DesarrolloTec.WEB.AuthenticationProviders
{
    public class AuthrnticationProvidersTest : AuthenticationStateProvider
    { 
            public override async Task<AuthenticationState> GetAuthenticationStateAsync()
            {
            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));
            }
        
    }
}
