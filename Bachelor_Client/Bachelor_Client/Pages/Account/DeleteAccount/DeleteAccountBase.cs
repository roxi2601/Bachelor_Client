using Microsoft.AspNetCore.Components;

namespace Bachelor_Client.Pages.Account.DeleteAccount;

public class DeleteAccountBase : ComponentBase
{
    protected bool ShowConfirmation { get; set; }

    [Parameter] public string ConfirmationTitle { get; set; } = "Confirm";
    [Parameter] public string Name { get; set; }
    [Parameter] public int ID { get; set; }

    [Parameter] public string ConfirmationMessage { get; set; }

    public void Show()
    {
        ShowConfirmation = true;
        StateHasChanged();
    }

    [Parameter] public EventCallback<bool> ConfirmationChanged { get; set; }

    protected async Task OnConfirmationChange(bool value)
    {
        ShowConfirmation = false;
        await ConfirmationChanged.InvokeAsync(value);
    }
}