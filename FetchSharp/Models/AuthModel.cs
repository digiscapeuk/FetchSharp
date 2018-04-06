using Newtonsoft.Json;

namespace FetchSharp.Models
{
    public class AuthModel
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}