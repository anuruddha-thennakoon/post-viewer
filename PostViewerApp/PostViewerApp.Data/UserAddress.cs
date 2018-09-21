using System;
using Newtonsoft.Json;

namespace PostViewerApp.Data
{
    public class UserAddress
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "suite")]
        public string Suite { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "geo")]
        public UserAddressGeo Geo { get; set; }
    }
}
