using System.Text;
using Bachelor_Client.Models;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Account;

public class AccountService : IAccountService
{
    private List<Models.Account> users = new();
    
    public async Task<Models.Account> GetLoggedAccount(Models.Account accountModel)
    {
        
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(accountModel),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage =
            await httpClient.PostAsync("https://localhost:7261/getAccount", content); 
        accountModel =
            JsonConvert.DeserializeObject<Models.Account>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return accountModel ;
        
    }

    public async Task CreateUser(Models.Account account)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(account),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage =
            await httpClient.PostAsync("https://localhost:7261/createAccount", content); 
        // account =
        //     JsonConvert.DeserializeObject<Models.Account>(responseMessage.Content.ReadAsStringAsync()
        //         .Result);
        // return accountModel ;
    }

    public async Task<List<Models.Account>> ReadAllAccounts()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/accounts"); 
        List<Models.Account> accountsDeSer =
            JsonConvert.DeserializeObject<List<Models.Account>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return users = accountsDeSer;
    }

    public async Task<List<Models.Account>> GetAllUsers()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/accounts"); //Change here
        List<Models.Account> accountDeSer =
            JsonConvert.DeserializeObject<List<Models.Account>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return users = accountDeSer;
    }
    public async Task DeleteAccount(int accountId)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage = await httpClient.DeleteAsync("https://localhost:7261/accounts/" + $"{accountId}");
        // if(responseMessage.Content.)
    }
}