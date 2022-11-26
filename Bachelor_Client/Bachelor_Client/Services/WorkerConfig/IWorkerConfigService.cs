

using Bachelor_Client.Models;

namespace Bachelor_Client.Services.WorkerConfig;

public interface IWorkerConfigService
{
    Task CreateWorkerConfiguration(WorkerConfiguration workerConfiguration);
    Task EditWorkerConfiguration(WorkerConfiguration workerConfigurationModel);
    Task<List<WorkerConfiguration>> ReadAllWorkerConfigurations();
    Task<List<WorkerStatistic>> ReadAllWorkerStatistics();
    Task DeleteWorkerConfiguration(int id);
    WorkerConfiguration GetWorkerConfigurationById(int id);
}