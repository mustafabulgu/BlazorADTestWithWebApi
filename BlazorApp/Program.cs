using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("BlazorApp.WebApi", client => client.BaseAddress = new Uri("https://localhost:7189/"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();



builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://mustestorg11.onmicrosoft.com/819e3dcd-8ef6-430f-abd1-6070f42cdbb0/Api.ReadWrite");
});


await builder.Build().RunAsync();
