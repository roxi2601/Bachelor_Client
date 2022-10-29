using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.Authorization
{
    public class BearerTokenModel
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
