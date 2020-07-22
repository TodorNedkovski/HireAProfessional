namespace HireAProfessional.Web.ViewModels.Json
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Newtonsoft.Json;

    public class JsonInputModel<Т>
    {
        [JsonProperty("data")]
        public List<Т> Data { get; set; }
    }
}
