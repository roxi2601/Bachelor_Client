using System.Security.Claims;
using Bachelor_Client;
using Bachelor_Client.Authentication;
using Bachelor_Client.Services.Account;
using Bachelor_Client.Services.Rest;
using Bachelor_Client.Services.Scheduling;
using Bachelor_Client.Services.WorkerConfig;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY0MDk4QDMyMzAyZTMzMmUzMFVtR05UKzhxRS9pRlpJM29XZFZTRDlCTTAzdm0xNG9FaHZUMXNrcFVsSlk9");
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
builder.Services.AddScoped<IRestService, RestService>();


builder.Services.AddAuthorizationCore(
    options =>
    {
        options.AddPolicy("loggedUser", policy => policy.RequireClaim("Type", "user"));
        options.AddPolicy("loggedAdmin", policy => policy.RequireClaim("Type", "admin"));
    }
);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AccountCustomAuthenticationStateProvider>();
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();