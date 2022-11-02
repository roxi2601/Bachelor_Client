namespace Bachelor_Client.Models
{
    public partial class Log
    {
        public int PkLogId { get; set; }
        public int FkWorkerId { get; set; }
        public string Date { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? StackTrace { get; set; }

        public virtual Worker FkWorker { get; set; } = null!;
    }
}
