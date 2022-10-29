

using Bachelor_Client.Models.General;
using Bachelor_Client.Models.WorkerConfiguration;

namespace Bachelor_Client.Services.WorkerConfig;

public interface IWorkerConfigService
{
    Task CreateWorkerConfiguration(string url, string requestType, List<ParametersHeaderModel> parameters, List<ParametersHeaderModel> headers, WorkerConfigData data);
    Task EditWorkerConfiguration(WorkerConfigurationModel workerConfigurationModel);
    Task<List<WorkerConfigurationModel>> ReadAllWorkerConfigurations();
    Task DeleteWorkerConfiguration(int id);
    WorkerConfigurationModel GetWorkerConfigurationById(int id);
}