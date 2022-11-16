using System.Text;
using Bachelor_Client.Models;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Scheduling;

public class ScheduleService : IScheduleService
{
    public async Task CreateWorker(Worker worker)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(worker),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:7261/scheduleWorker", content);
    }
}