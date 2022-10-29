using System.Text;
using Bachelor_Client.Models.General;
using Bachelor_Client.Models.WorkerConfiguration;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.WorkerConfig;

public class WorkerConfigService : IWorkerConfigService
{
    private List<WorkerConfigurationModel> workerConfigs = new();
    public async Task CreateWorkerConfiguration(string url, string requestType, List<ParametersHeaderModel> parameters, List<ParametersHeaderModel> headers, WorkerConfigData data)
    {
        WorkerConfigurationModel config = new WorkerConfigurationModel()
            {
                url = url,
                requestType = requestType,
                parameters = parameters,
                headers = headers,
                Data = data
            };

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(config),
                Encoding.UTF8,
                "application/json"
            );
            await httpClient.PostAsync("https://localhost:8080/workerConfig", content);
    }

    public async Task EditWorkerConfiguration(WorkerConfigurationModel workerConfigurationModel)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(workerConfigurationModel),  
            Encoding.UTF8,
            "application/json"
        );
        await httpClient.PatchAsync("https://localhost:8080/workerConfig/", content);
    }

    public WorkerConfigurationModel GetWorkerConfigurationById(int workerConfigId)
    {
        return workerConfigs.Find(w => w.ID == workerConfigId);
    }

    public async Task<List<WorkerConfigurationModel>> ReadAllWorkerConfigurations()
    {
        HttpClient httpClient = new HttpClient();  
        HttpResponseMessage responseMessage =                       
            await httpClient.GetAsync("https://localhost:8080/workerConfig/"); //Change here
        List<WorkerConfigurationModel> workerConfigsDeSer = JsonConvert.DeserializeObject<List<WorkerConfigurationModel>>(responseMessage.Content.ToString());
        return workerConfigs = workerConfigsDeSer;
    }

    public async Task DeleteWorkerConfiguration(int workerConfigId)
    {
        HttpClient httpClient = new HttpClient();
        await httpClient.DeleteAsync("https://localhost:8080/workerConfig/" + $"{workerConfigId}");
    }
}