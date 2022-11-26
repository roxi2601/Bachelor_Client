using Bachelor_Client.Models;

namespace Bachelor_Client.Services.Scheduling;

public interface IScheduleService
{
    Task CreateWorker(WorkerConfiguration worker);
}