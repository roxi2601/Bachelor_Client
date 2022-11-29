using Microsoft.AspNetCore.Components;

namespace Bachelor_Client.Pages.StatisticsCharts;

public class StatisticsChartsBase : ComponentBase
{
    protected bool ShowConfirmation { get; set; }
    [Parameter] public int workerStatisticsID { get; set; }
    [Parameter] public int duration { get; set; }
    [Parameter] public int numberOfFailedRuns { get; set; }
    [Parameter] public string URL { get; set; }
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