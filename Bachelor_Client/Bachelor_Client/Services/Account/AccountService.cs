using Bachelor_Client.Models.Account;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Account;

public class AccountService : IAccountService
{
    public async Task<AccountModel> GetLoggedAccount(AccountModel accountModel)
    {
        
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/account"); 
        accountModel =
            JsonConvert.DeserializeObject<AccountModel>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return accountModel ;
        
    }
}