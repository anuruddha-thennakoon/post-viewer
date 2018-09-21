using System;
using Newtonsoft.Json;

namespace PostViewerApp.Data
{
    public class UserAddressGeo
    {
        [JsonProperty(PropertyName = "lat")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double? Longitude { get; set; }
    }
}
