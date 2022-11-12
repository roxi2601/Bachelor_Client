

namespace Bachelor_Client.Services.Account;

public interface IAccountService
{
    Task<Models.Account> GetLoggedAccount(Models.Account accountModel);

    Task CreateAccount(Models.Account account);
    Task<List<Models.Account>> ReadAllAccounts();
    Task DeleteAccount(int id);
    Models.Account GetAccountById(int id);
    Task EditAccount(Models.Account account);
}