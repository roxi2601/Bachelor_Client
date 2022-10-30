using Bachelor_Client.Authentication;
using Bachelor_Client.Pages.WorkerConfiguration;
using Bachelor_Client.Services.Account;
using Bachelor_Client.Services.Rest;
using Bachelor_Client.Services.WorkerConfig;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


public class UnitTest1
{
    // Presentation Layer is mostly tested using Black Box method - see appendix
    [Fact]
    public async Task CreateWorkerConfigTest()
    {
        // Arrange
        var ctx = new TestContext();
        ctx.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
        ctx.Services.AddScoped<IRestService, RestService>();
        var nav = ctx.Services.GetRequiredService<NavigationManager>();
        var component = ctx.RenderComponent<CreateWorkerConfig>();
        
        // Act
        component.Find(".button-5").Click();
        
        // Assert
        component.Find(".errorLabel").MarkupMatches("<div class=\"errorLabel\">Please, specify the URL</div>"); 
        Assert.NotEqual("http://localhost/WorkerConfigurationsList", nav.Uri);
    }
    //

    /*[Fact]
    public async Task EditWorkerConfigTest()
    {
        // Arrange
        var ctx = new TestContext();

        ctx.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
        ctx.Services.AddScoped<IWorkerConfigurationRepo, WorkerConfigurationRepo>();
        ctx.Services.AddScoped<ILogHandling, LogHandling>();
        var nav = ctx.Services.GetRequiredService<NavigationManager>();

        
        WorkerConfigurationModel workerConfigurationModel = new WorkerConfigurationModel()
        {
            ID = 30
        };
        
        var component = ctx.RenderComponent<EditWorkerConfig>(parameters => parameters
            .Add(p => p.workerConfigID, workerConfigurationModel.ID.ToString()));
      

        // Act
        component.Find(".button-5").Click();
        
        // Assert
        component.Find(".errorLabel").MarkupMatches("<div class=\"errorLabel\">Please, specify the URL</div>"); 
        Assert.NotEqual("http://localhost/WorkerConfigurationsList", nav.Uri);
    }

    [Fact]
    public async Task ReadWorkerConfigsTest()
    {
        // Arrange
        var ctx = new TestContext();

        ctx.Services.AddScoped<IWorkerConfigService, WorkerConfigService>();
        ctx.Services.AddScoped<IWorkerConfigurationRepo, WorkerConfigurationRepo>();
        ctx.Services.AddScoped<ILogHandling, LogHandling>();
        ctx.Services.AddScoped<IRestService, RestService>();
        ctx.Services.AddScoped<IExportService, ExportService>();
        
        WorkerConfigurationsList page = new WorkerConfigurationsList();
        WorkerConfigurationModel workerConfigurationModel1 = new WorkerConfigurationModel();
        WorkerConfigurationModel workerConfigurationModel2 = new WorkerConfigurationModel();

        page.WorkerConfigList.Add(workerConfigurationModel1);
        page.WorkerConfigList.Add(workerConfigurationModel2);
        var component = ctx.RenderComponent<WorkerConfigurationsList>();
        
        component.Find(".id").Matches("ID");
        component.Find(".url").Matches("Worker Configuration");
        component.Find(".actions").Matches("Actions");
    }*/
    
  
}