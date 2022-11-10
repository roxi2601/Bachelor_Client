using System.Text;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Account;

public class AccountService : IAccountService
{
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
}