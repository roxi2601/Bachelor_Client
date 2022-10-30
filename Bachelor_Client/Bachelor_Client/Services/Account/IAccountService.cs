using Bachelor_Client.Models.Account;

namespace Bachelor_Client.Services.Account;

public interface IAccountService
{
    Task<AccountModel> GetLoggedAccount(AccountModel accountModel);
}