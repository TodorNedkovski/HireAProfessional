namespace HireAProfessional.Services.Json
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;

    public class LocationJsonModel
    {
        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("city")]
        public string CityName { get; set; }
    }
}
