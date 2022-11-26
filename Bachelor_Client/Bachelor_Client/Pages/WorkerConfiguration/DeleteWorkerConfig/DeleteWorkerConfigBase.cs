using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Bachelor_Client.Pages.WorkerConfiguration.DeleteWorkerConfig
{
    public class DeleteWorkerConfigBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter] public string ConfirmationTitle { get; set; } = "Confirm";
        [Parameter] public string URL { get; set; }
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
}