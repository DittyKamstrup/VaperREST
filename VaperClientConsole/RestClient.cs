﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VaperREST;
using System.Net.Http.Headers;

namespace VaperClientConsole
{
    class RestClient
    {

        //CONNECTION STRING

            //LOCAL
        private const string uri = "http://localhost:1291/Service1.svc";

            //AZURE
        //private const uri2 = "http://vaperrestservice.azurewebsites.net/Service1.svc";

        //DEFAULT CONSTRUCTOR
        public RestClient()
        {

        }



        private async Task<IList<Vaper>> GetVapersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/vapers");
                IList<Vaper> vList = JsonConvert.DeserializeObject<IList<Vaper>>(content);
                return vList;
            }
        }

        private async Task<Vaper> GetOneVaperAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(uri + "/vaper/" + id);
                Vaper v = JsonConvert.DeserializeObject<Vaper>(content);
                return v;
            }
        }

        private async Task<Vaper> DeleteVaperAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = await client.DeleteAsync(uri + "/vapers?id=" + id);
                Vaper v = JsonConvert.DeserializeObject<Vaper>(content.Content.ReadAsStringAsync().Result);
                return v;
            }
        }

        private async void AddVaperAsync(Vaper newVaper)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(newVaper));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(uri + "/vapers", content);

            }
        }
    }
}
