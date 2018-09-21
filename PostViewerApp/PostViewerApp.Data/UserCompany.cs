using Newtonsoft.Json;

namespace PostViewerApp.Data
{
    public class UserCompany
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty(PropertyName = "bs")]
        public string BusinessStrategy { get; set; }
    }
}
