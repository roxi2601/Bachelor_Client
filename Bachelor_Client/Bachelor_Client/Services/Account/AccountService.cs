using System.Text;
using Bachelor_Client.Models.Account;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Account;

public class AccountService : IAccountService
{
    public async Task<AccountModel> GetLoggedAccount(AccountModel accountModel)
    {
        
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(accountModel),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage =
            await httpClient.PostAsync("https://localhost:7261/account", content); 
        accountModel =
            JsonConvert.DeserializeObject<AccountModel>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return accountModel ;
        
    }
}