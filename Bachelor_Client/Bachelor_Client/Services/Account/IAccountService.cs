

namespace Bachelor_Client.Services.Account;

public interface IAccountService
{
    Task<Models.Account> GetLoggedAccount(Models.Account accountModel);

    Task CreateUser(Models.Account account);
    Task<List<Models.Account>> ReadAllAccounts();
    Task DeleteAccount(int id);
}