using System.Security.Claims;
using Bachelor_Client;
using Bachelor_Client.Authentication;
using Bachelor_Client.Services.Account;
using Bachelor_Client.Services.Rest;
using Bachelor_Client.Services.WorkerConfig;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<AuthenticationStateProvider, AccountCustomAuthenticationStateProvider>();
builder.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
builder.Services.AddScoped<IRestService, RestService>();


builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("loggedAccount", policy =>
        policy.RequireAuthenticatedUser().RequireAssertion(context =>
        {
            Claim logClaim = context.User.FindFirst(claim => claim.Type.Equals("Email"));
            if (logClaim == null)
            {
                return false;
            }
            return true;
        }));
});
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();