﻿
using System.Security.Claims;
using System.Text.Json;
using Bachelor_Client.Models.Account;
using Bachelor_Client.Services.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;


namespace Bachelor_Client.Authentication
{
    public class AccountCustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly IAccountService accountService;

        private AccountModel cachedAccount;

        public AccountCustomAuthenticationStateProvider(IJSRuntime jsRuntime, IAccountService accountService)
        {
            this.jsRuntime = jsRuntime;
            this.accountService = accountService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedAccount == null )
            {
                string accountAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "accountUser");
                if (!string.IsNullOrEmpty(accountAsJson))
                {
                    cachedAccount = JsonSerializer.Deserialize<AccountModel>(accountAsJson);
                    
                    identity = SetupClaimsForAccount(cachedAccount);
                }
            }
            else
            {
                identity = SetupClaimsForAccount(cachedAccount);
                
            }
         
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(AccountModel accountModel)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(accountModel.Email)) throw new Exception("Enter email");
            if (string.IsNullOrEmpty(accountModel.Password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                AccountModel account = await accountService.GetLoggedAccount(accountModel);
                identity = SetupClaimsForAccount(account);
                string serialisedData = JsonSerializer.Serialize(account);
               await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentAccount", serialisedData);
                cachedAccount = account;
            } catch (Exception e) {
                Console.WriteLine(e);
                throw e;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        
        public void Logout()
        {
            
            cachedAccount = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentAccount", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetupClaimsForAccount(AccountModel accountModel)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Email", accountModel.Email));
            claims.Add(new Claim("Password", accountModel.Password));
            claims.Add(new Claim("SecurityLevel", accountModel.SecurityLevel.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
        
       
    }
}