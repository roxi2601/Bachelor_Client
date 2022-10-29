using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bachelor_Client.Models.Authorization
{
    public class OAuth1Model
    {
        [Key]
        public int Id { get; set; }
        public string SignatureMethod { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string CallbackURL { get; set; }
        public string Timestamp { get; set; }
        public string Nonce { get; set; }
        public string Version { get; set; }
        public string Realm { get; set; }
        public string IncludeBodyHash { get; set; }
        public string EmptyParamToSig { get; set; }
    }
}
