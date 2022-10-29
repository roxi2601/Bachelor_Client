using Bachelor_Client;
using Bachelor_Client.Services.Account;
using Bachelor_Client.Services.Rest;
using Bachelor_Client.Services.WorkerConfig;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
builder.Services.AddScoped<IRestService, RestService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();