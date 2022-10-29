using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.Body
{
    public class RawModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

    }
}
