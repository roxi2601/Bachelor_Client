using Bachelor_Client.Models;

namespace Bachelor_Client.Services.Statistics;

public interface IWorkerStatistics
{
    Task<List<WorkerStatistic>> ReadAllWorkerStatistics();
}