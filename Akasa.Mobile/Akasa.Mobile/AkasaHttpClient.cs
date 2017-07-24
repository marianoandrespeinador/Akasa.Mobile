using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Akasa.Mobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Akasa.Mobile
{
    public class AkasaHttpClient
    {
        const string JsonContentType = "application/json";

        public async Task<TOut> Post<TIn, TOut>(string path, TIn contentToPost)
        {
            var toReturn = default(TOut);

            try
            {
                var oJsonObject = JObject.FromObject(contentToPost);
                var client = new HttpClient();
                var response = await client.PostAsync(path, new StringContent(oJsonObject.ToString(), Encoding.UTF8, JsonContentType));
                var content = await response.Content.ReadAsStringAsync();
                toReturn = JsonConvert.DeserializeObject<TOut>(content);
            }
            catch (Exception e)
            {
                //DisplayAlert("Alert", "Error on insert", "OK");
            }

            return toReturn;
        }

        public async Task<T> Get<T>(string path)
        {
            var toReturn = default(T);

            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(path);
                var content = await response.Content.ReadAsStringAsync();
                toReturn = JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception e)
            {
                //DisplayAlert("Alert", "Error on insert", "OK");
            }

            return toReturn;
        }
    }
}
