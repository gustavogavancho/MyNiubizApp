using System.Collections.Generic;

namespace MyNiubizApp.Models
{
    public class CredentialResponseModel
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public List<Key> keys { get; set; }
        public int expiresIn { get; set; }
    }
    public class Key
    {
        public string token { get; set; }
        public string baseKey { get; set; }
        public string iv { get; set; }
    }
}
