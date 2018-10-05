using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace UnitransMVCWebApp
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();
        //singleton webclient so i dont flood the memory and crash the site with web requests
        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:52936/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}