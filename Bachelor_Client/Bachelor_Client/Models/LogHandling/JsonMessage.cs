using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.LogHandling
{
    public class JsonMessage
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public string Exception { get; set; }
        public DateTime Date { get; set; }
    }
}
