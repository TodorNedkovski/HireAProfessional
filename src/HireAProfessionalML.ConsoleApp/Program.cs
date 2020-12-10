
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HireAProfessional.Data.Common.Repositories;
using HireAProfessional.Data.Models;
using HireAProfessional.Data.Repositories;
using HireAProfessional.Services.Data;
using HireAProfessional.Web.ViewModels.Comments;
using HireAProfessionalML.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace HireAProfessionalML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var comments = JsonConvert.DeserializeObject<ICollection<CommentViewModel>>(response.Content);
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                SentimentText = @"==RUDE== Dude, you are rude upload that carl picture back, or else.",
                LoggedIn = @"TRUE",
            };

            foreach (var comment in comments)
            {
                sampleData.SentimentText = comment.Content;
                var predictionResult = ConsumeModel.Predict(sampleData);
            }

            Console.ReadKey();
        }
    }
}
