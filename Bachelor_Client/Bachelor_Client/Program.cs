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

builder.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
builder.Services.AddScoped<IRestService, RestService>();


builder.Services.AddAuthorizationCore(
    options =>
    {
        options.AddPolicy("loggedAccount", policy => policy.RequireClaim("Type", "admin"));
            // policy => policy.RequireAuthenticatedUser().RequireAssertion(
            //     context =>
            //     {
            //         return context.User.Claims.FirstOrDefault(claim => claim.Type.Equals("Type")).Value.Equals("admin");
            //     }
            // )
        
    }
);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AccountCustomAuthenticationStateProvider>();
await builder.Build().RunAsync();