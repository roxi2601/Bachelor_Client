using Bachelor_Client.Models;

namespace Bachelor_Client.Services.Rest;

public interface IRestService
{
    Task<string> ExportExcel(string content);

    Task<string> ExportCSV(string content);

    Task<string> GenerateRequest(WorkerConfiguration workerConfigurationModel, string requestType);
}