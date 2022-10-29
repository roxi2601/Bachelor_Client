

namespace Bachelor_Client.Services.Rest;

public interface IRestService
{
      Task<string> ExportExcel(string content);

      Task<string> ExportCSV(string content);
      
      Task<string> GenerateRequest(int workerConfigId, string requestType);
      
      
      
      
      // Task<string> GenerateGetRequest(WorkerConfigurationModel workerConfigurationModel);
      // Task<string> GeneratePostRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText);
      // Task<string> GeneratePostRequestFormData(WorkerConfigurationModel workerConfigurationModel, List<FormDataModel> formDataModel);
      // Task<string> GeneratePutRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText);
      // Task<string> GeneratePutRequestFormdata(WorkerConfigurationModel workerConfigurationModel, List<FormDataModel> formDataModel);
      // Task<string> GeneratePatchRequestRaw(WorkerConfigurationModel workerConfigurationModel, string rawModelText);
      // Task<string> GeneratePatchRequestFormdata(WorkerConfigurationModel workerConfigurationModel, List<FormDataModel> formDataModel);
      // Task<string> GenerateDeleteRequest(WorkerConfigurationModel workerConfigurationModel);
}