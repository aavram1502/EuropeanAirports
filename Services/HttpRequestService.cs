using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Services
{
    public class HttpRequestService : IHttpRequestService
    {
        public List<T> SendRequest<T>(string jsonFeed)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(jsonFeed).Result;

                    if (response == null || !response.IsSuccessStatusCode) return new List<T>();

                    var responseString = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<List<T>>(responseString);
                }
                catch (Exception)
                {
                    return new List<T>();
                }
            }
        }
    }
}
