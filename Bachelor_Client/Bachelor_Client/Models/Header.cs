using System;
using System.Collections.Generic;

namespace Bachelor_Client.Models{
    public partial class Header
    {
        public int PkHeaderId { get; set; }
        public int FkWorkerConfigurationId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }

        public virtual WorkerConfiguration FkWorkerConfiguration { get; set; } = null!;
    }
}
