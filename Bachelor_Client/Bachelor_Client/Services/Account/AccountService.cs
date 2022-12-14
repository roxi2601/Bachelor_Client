using System.Text;
using Newtonsoft.Json;

namespace Bachelor_Client.Services.Account;

public class AccountService : IAccountService
{
    private List<Models.Account> accounts = new();

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
        return accountModel;
    }

    public async Task<string> CreateAccount(Models.Account account)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(account),
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage responseMessage =
            await httpClient.PostAsync("https://localhost:7261/createAccount", content);
        return responseMessage.Content.ReadAsStringAsync()
            .Result;
    }

    public async Task<string> EditAccount(Models.Account account)
    {
        HttpClient httpClient = new HttpClient();
        StringContent content = new StringContent(
            JsonConvert.SerializeObject(account),
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage responseMessage =
            await httpClient.PatchAsync("https://localhost:7261/editAccount", content);
        return responseMessage.Content.ReadAsStringAsync()
            .Result;
    }

    public async Task<List<Models.Account>> ReadAllAccounts()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.GetAsync("https://localhost:7261/accounts");
        List<Models.Account> accountsDeSer =
            JsonConvert.DeserializeObject<List<Models.Account>>(responseMessage.Content.ReadAsStringAsync()
                .Result);
        return accounts = accountsDeSer;
    }

    public Models.Account GetAccountById(int accountID)
    {
        return accounts.Find(a => a.PkAccountId == accountID);
    }

    public async Task DeleteAccount(int accountId)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage =
            await httpClient.DeleteAsync("https://localhost:7261/deleteAccount/" + $"{accountId}");
    }
}