using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using SnackFood.Models;

namespace SnackFood.Repositories
{
    public class VotesRepo
    {
        public void Post(ExistingSnacks snack)
        {
            Uri ourUri = new Uri("https://api-snacks.nerderylabs.com/v1/snacks/");

            WebRequest myWebRequest = WebRequest.Create(ourUri);

            myWebRequest.Headers["Authorization"] = "ApiKey fe152ad3-bbef-4452-aad1-baa0cd10532d";

            myWebRequest.Method = "Post";

            string json = JsonConvert.SerializeObject(snack);

            myWebRequest.ContentLength = json.Length;

            Stream dataStream = myWebRequest.GetRequestStream();

            var theRequest = new StreamWriter(dataStream);
            
            theRequest.Write(theRequest);              
            
        }
    }
}