using Microsoft.AspNetCore.Components;

namespace Bachelor_Client.Pages.WorkerConfiguration.Scheduling;

public class ScheduleWorkerBase: ComponentBase
{
    protected bool ShowConfirmation { get; set; }

    [Parameter]
    public string ConfirmationTitle { get; set; } = "Schedule Worker";
   
    [Parameter]
    public int ID { get; set; } 
    [Parameter]
    public DateTime DateTime { get; set; } 
    [Parameter]
    public string Frequency1 { get; set; } 
    [Parameter]
    public string Frequency2 { get; set; } 

    [Parameter]
    public string ConfirmationMessage { get; set; }

    public void Show()
    {
        ShowConfirmation = true;
        StateHasChanged();
    }

    [Parameter]
    public EventCallback<bool> ConfirmationChanged { get; set; }

    protected async Task OnConfirmationChange(bool value)
    {
        ShowConfirmation = false;
        await ConfirmationChanged.InvokeAsync(value);
    }
}