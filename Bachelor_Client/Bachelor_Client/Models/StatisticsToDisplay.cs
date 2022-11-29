namespace Bachelor_Client.Models;

public class StatisticsToDisplay
{
    public int ID { get; set; }
    public string URL { get; set; }
    public double duration { get; set; }
    public bool isActive { get; set; }
    public int numberOfFailedRuns { get; set; }
    public string status { get; set; }
}