using System.Text;
using Aspose.Cells;
using Aspose.Cells.Utility;
using Bachelor_Client.Models.WorkerConfiguration;
using Newtonsoft.Json;


namespace Bachelor_Client.Services.Rest;

public class RestService : IRestService
{
    private string CachedContent { get; set; } = "";
    
    public async Task<string> GenerateRequest(WorkerConfigurationModel workerConfigurationModel, string requestType)
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
            return CachedContent = responseMessage.Content.ToString();
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

        if (content != null && !content.Equals("The URL is not valid"))
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

        if (content != null && !content.Equals("The URL is not valid"))
        {
            JsonUtility.ImportData(content, worksheet.Cells, 0, 0, options);
            workbook.Save("Import-Data-JSON-To-CSV.csv");
            status = "File Exported";
        }
        else status = "Cannot export the file";
        
        return Task.FromResult(status);
    }

    // public Task<string> GeneratePostRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GeneratePostRequestFormData(WorkerConfigurationModel workerConfigurationModel,
    //     List<FormDataModel> formDataModel)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GeneratePutRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GeneratePutRequestFormdata(WorkerConfigurationModel workerConfigurationModel,
    //     List<FormDataModel> formDataModel)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GeneratePatchRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GeneratePatchRequestFormdata(WorkerConfigurationModel workerConfigurationModel,
    //     List<FormDataModel> formDataModel)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public Task<string> GenerateDeleteRequest(WorkerConfigurationModel workerConfigurationModel)
    // {
    //     throw new NotImplementedException();
    // }
}