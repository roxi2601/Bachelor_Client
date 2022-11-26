using System.Text;
using Bachelor_Client.Models;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.WorkerConfig;

public class WorkerConfigService : IWorkerConfigService
{
    private List<WorkerConfiguration> workerConfigs = new();
    private List<WorkerStatistic> workerStats = new();

    public async Task CreateWorkerConfiguration(WorkerConfiguration workerConfiguration)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(workerConfiguration),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7261/workerConfig", content);
    }

    public async Task EditWorkerConfiguration(WorkerConfiguration workerConfigurationModel)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(workerConfigurationModel),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage = await httpClient.PatchAsync("https://localhost:7261/workerConfig/", content);
    }

    public WorkerConfiguration GetWorkerConfigurationById(int workerConfigId)
    {
        return workerConfigs.Find(w => w.PkWorkerConfigurationId == workerConfigId);
    }

    public async Task<List<WorkerConfiguration>> ReadAllWorkerConfigurations()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/workerConfig"); //Change here
        List<WorkerConfiguration> workerConfigsDeSer =
            JsonConvert.DeserializeObject<List<WorkerConfiguration>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return workerConfigs = workerConfigsDeSer;
    }
    public async Task<List<WorkerStatistic>> ReadAllWorkerStatistics()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/workerStats"); 
        List<WorkerStatistic> workerStatsDeSer =
            JsonConvert.DeserializeObject<List<WorkerStatistic>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return workerStats = workerStatsDeSer;
    }
    public async Task DeleteWorkerConfiguration(int workerConfigId)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage = await httpClient.DeleteAsync("https://localhost:7261/workerConfig/" + $"{workerConfigId}");
       // if(responseMessage.Content.)
    }
}