using System.ComponentModel.DataAnnotations;

namespace Bachelor_Client.Models.Account
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        public int SecurityLevel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
    }
}
