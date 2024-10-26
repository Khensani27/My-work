using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinalYearWeb.Controllers
{
    public class Base<T>
    {
        private HttpClient client;
        public Base()
        {
            client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("http://localhost:5280/api/");
            //client.BaseAddress = new Uri("https://team8webapi20231003031146.azurewebsites.net/api/");
        }
        /*Function for getting a list of objects from the database
         * takes in a string of the ur of the function you calling from the api
         */
        public async Task<List<T>> GetAll(string url)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetAsync(client.BaseAddress + url);
            if (!response.IsSuccessStatusCode)
                return null;

            if (response != null)
            {
                //response.EnsureSuccessStatusCode();
                var strResponse = await response.Content.ReadAsStringAsync();
                List<T> loggeduser = JsonConvert.DeserializeObject<List<T>>(strResponse);
                return loggeduser;
            }
            return null;
        }
        /*Function for getting an object from the database
        * takes in a string of the ur of the function you calling from the api
        */
        public async Task<T> Get(string url)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetAsync(client.BaseAddress + url);
            if (!response.IsSuccessStatusCode)
                return default(T);

            if (response != null)
            {
                response.EnsureSuccessStatusCode();
                var strResponse = await response.Content.ReadAsStringAsync();

                T loggeduser = JsonConvert.DeserializeObject<T>(strResponse);
                return loggeduser;
            }
            return default(T);
        }
  

        public async Task<HttpResponseMessage> Create(string url, Object obj)
        {
            var httprequest = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + url);
            if (obj != null)
            {
                httprequest.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage httpResponse = await client.SendAsync(httprequest);
            if (httpResponse.IsSuccessStatusCode)
            {
                return httpResponse;
            }
            return null;
        }

        /*Function for editing an object in the database
 * takes in a string of the ur of the function you calling from the api and the object to edit
 */
        public async Task<HttpResponseMessage> Edit(string url, Object obj)
        {
            var httprequest5 = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress + url);
            if (obj != null)
            {
                httprequest5.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage httpResponse = await client.SendAsync(httprequest5);
            if (httpResponse.IsSuccessStatusCode)
            {
                return httpResponse;
            }
            return null;
        }
        //public async Task<HttpResponseMessage> Edit(string url)
        //{
        //    var httprequest5 = new HttpRequestMessage(HttpMethod.Put, client.BaseAddress + url);
        //    HttpResponseMessage httpResponse = await client.SendAsync(httprequest5);
        //    if (httpResponse.IsSuccessStatusCode)
        //    {
        //        return httpResponse;
        //    }
        //    return null;
        //}

        public async Task<bool> Delete(string url, Object obj)
        {
            var httprequest5 = new HttpRequestMessage(HttpMethod.Delete, client.BaseAddress + url);
            HttpResponseMessage httpResponse = await client.DeleteAsync(url);
            if(httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
            
        }


        public async Task<bool> GetBool(string url)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetAsync(client.BaseAddress + url);
            if (response != null)
            {
                //response.EnsureSuccessStatusCode();
                var strResponse = await response.Content.ReadAsStringAsync();

                bool TF = JsonConvert.DeserializeObject<bool>(strResponse);
                return TF;
            }
            return false;
        }
    }
}