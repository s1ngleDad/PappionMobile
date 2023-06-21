using Newtonsoft.Json;
using PappionMobile.Models.Event;
using PappionMobile.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Endpoints.PappionBackend
{
    public class EventEndpoint
    {
        private const string eventsUrl = "";

        public async Task<List<EventModel>> GetAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync(eventsUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            List<EventModel> list = JsonConvert.DeserializeObject<List<EventModel>>(result.ToString());

            return list;
        }

        public async Task<EventModel> GetAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{eventsUrl}/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            EventModel post = JsonConvert.DeserializeObject<EventModel>(result.ToString());

            return post;
        }

        public async Task<EventModel> CreateAsync(EventModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(eventsUrl, data);
            var result = await response.Content.ReadAsStringAsync();
            EventModel eventModel = JsonConvert.DeserializeObject<EventModel>(result.ToString());
            return eventModel;
        }

        public async Task<EventModel> UpdateAsync(PostModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PutAsync(eventsUrl, data);
            var result = await response.Content.ReadAsStringAsync();
            EventModel eventModel = JsonConvert.DeserializeObject<EventModel>(result.ToString());
            return eventModel;
        }

        public async Task DeleteAsync(int Id)
        {
            using var client = new HttpClient();
            var uri = Path.Combine(eventsUrl, $"{Id}");
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
