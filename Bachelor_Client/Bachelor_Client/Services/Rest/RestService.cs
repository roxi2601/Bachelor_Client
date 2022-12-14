using System.Text;
using Aspose.Cells;
using Aspose.Cells.Utility;
using Bachelor_Client.Models;
using Newtonsoft.Json;
namespace Bachelor_Client.Services.Rest;

public class RestService : IRestService
{
    private string CachedContent { get; set; } = "";
    public async Task<string> GenerateRequest(WorkerConfiguration workerConfigurationModel, string requestType)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(workerConfigurationModel),
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage responseMessage =
                await httpClient.PostAsync("https://localhost:7261/requests/" + $"{requestType}", content);
            return CachedContent = await responseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
    public Task<string> ExportExcel(string content)
    {
        content = CachedContent;
        Workbook workbook = new Workbook();
        Worksheet worksheet = workbook.Worksheets[0];
        JsonLayoutOptions options = new JsonLayoutOptions();
        options.ArrayAsTable = true;
        string status;

        if (content != null && !content.Equals("The URL is not valid") && !content.Contains("\"StatusCode\":400\"") &&
            !content.Contains("Invalid URI"))
        {
            JsonUtility.ImportData(content, worksheet.Cells, 0, 0, options);
            workbook.Save("Import-Data-JSON-To-Excel.xlsx");
            status = "File Exported";
        }
        else status = "Cannot export the file";

        return Task.FromResult(status);
    }

    public Task<string> ExportCSV(string content)
    {
        content = CachedContent;
        Workbook workbook = new Workbook();
        Worksheet worksheet = workbook.Worksheets[0];
        JsonLayoutOptions options = new JsonLayoutOptions();
        options.ArrayAsTable = true;
        string status;

        if (content != null && !content.Equals("The URL is not valid") && !content.Contains("\"StatusCode\":400\"") &&
            !content.Contains("Invalid URI"))
        {
            JsonUtility.ImportData(content, worksheet.Cells, 0, 0, options);
            workbook.Save("Import-Data-JSON-To-CSV.csv");
            status = "File Exported";
        }
        else status = "Cannot export the file";
        return Task.FromResult(status);
    }
}