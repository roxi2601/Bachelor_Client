using Microsoft.AspNetCore.Components;

namespace Bachelor_Client.Pages.WorkerConfiguration.Scheduling;

public class ScheduleWorkerBase : ComponentBase
{
    protected bool ShowConfirmation { get; set; }

    [Parameter] public string ConfirmationTitle { get; set; } = "Schedule Worker";

    [Parameter] public int ID { get; set; }

    public DateTime DateTime = DateTime.Now;

    public string Frequency1 = "1";

    public string Frequency2 = "min";
    public bool IsActive = true;

    public void OnActiveChanged(object args)
    {
        if (string.IsNullOrEmpty(args.ToString()))
        {
            return;
        }

        bool.TryParse(args.ToString(), out var result);
        IsActive = result;
    }

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