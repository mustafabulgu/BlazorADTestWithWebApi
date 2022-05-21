using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorApp
{


    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:7189/" },
                scopes: new[] { "https://mustestorg11.onmicrosoft.com/819e3dcd-8ef6-430f-abd1-6070f42cdbb0/Api.ReadWrite" });
        }
    }
}
