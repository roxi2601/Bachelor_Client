using Microsoft.AspNetCore.Components;

namespace Bachelor_Client.Pages.WorkerConfiguration.SendRequest
{
    public class SendRequestBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter] public string ConfirmationTitle { get; set; } = "Response";

        [Parameter] public string? Content { get; set; }
        [Parameter] public string messageExport { get; set; }

        [Parameter] public string Name { get; set; }

        public void Show()
        {
            messageExport = "";
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
}