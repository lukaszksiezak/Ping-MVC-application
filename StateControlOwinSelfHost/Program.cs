using Microsoft.Owin.Hosting;
using OwinSelfhostSample;
using System;
using System.Net.Http;

namespace StateControlOwinSelfHost
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

            }

            Console.ReadLine();
        }
    }
}