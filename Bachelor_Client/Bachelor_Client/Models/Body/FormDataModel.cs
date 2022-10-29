using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.Body
{
    public class FormDataModel
    {
        [Key]
        public int Id { get; set; }
        public int WorkerConfiguationID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
