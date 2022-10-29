using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.Authorization
{
    public class OAuth2Model
    {
        [Key]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string HeaderPrefix { get; set; }
    }
}
