using Bachelor_Client.Models;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Statistics;

public class WorkerStatistics: IWorkerStatistics
{
    private List<WorkerStatistic> workerStats = new();
    public async Task<List<WorkerStatistic>> ReadAllWorkerStatistics()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/getAllStatistics");
        List<WorkerStatistic> workerStatsDeSer =
            JsonConvert.DeserializeObject<List<WorkerStatistic>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return workerStats = workerStatsDeSer;
    }

    public WorkerStatistic GetWorkerStatisticById(int id)
    {
        return workerStats.Find(w => w.PkWorkerStatisticsId == id);
    }
}