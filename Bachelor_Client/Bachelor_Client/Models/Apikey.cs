using System;
using System.Collections.Generic;

namespace Bachelor_Client.Models{
    public partial class Apikey
    {
        public Apikey()
        {
            WorkerConfigurations = new HashSet<WorkerConfiguration>();
        }

        public int PkApikeyId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? AddTo { get; set; }

        public virtual ICollection<WorkerConfiguration> WorkerConfigurations { get; set; }
    }
}
