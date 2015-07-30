using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SnackFood.Models;
using System.IO;
using Newtonsoft.Json;

namespace SnackFood.Controllers.api
{
    public class VotesController : ApiController
    {
        public List<ExistingSnacks> Get()
        {

            Uri ourUri = new Uri("https://api-snacks.nerderylabs.com/v1/snacks/");

            WebRequest myWebRequest = WebRequest.Create(ourUri);

            myWebRequest.Headers["Authorization"] = "ApiKey fe152ad3-bbef-4452-aad1-baa0cd10532d";

            var theRequest = new StreamReader(myWebRequest.GetResponse().GetResponseStream());

            var body = theRequest.ReadToEnd();
            List<ExistingSnacks> snackList = JsonConvert.DeserializeObject<List<ExistingSnacks>>(body);
            
            return snackList;
           
        }
           
    }
}
