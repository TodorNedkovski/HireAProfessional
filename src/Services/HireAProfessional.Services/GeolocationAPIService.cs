namespace HireAProfessional.Services
{
    using System.Text.RegularExpressions;

    using HireAProfessional.Services.Json;
    using Newtonsoft.Json;
    using RestSharp;

    public static class GeolocationAPIService
    {
        public static LocationJsonModel GetCurrentLocation()
        {
            var url = "https://geolocation-db.com/jsonp";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("jsonpCallback", "callback");
            request.AddHeader("dataType", "jsonp");
            IRestResponse response = client.Execute(request);

            var content = Regex.Replace(response.Content, @"^.+?\(|\)$", string.Empty);

            return JsonConvert.DeserializeObject<LocationJsonModel>(content);
        }
    }
}
