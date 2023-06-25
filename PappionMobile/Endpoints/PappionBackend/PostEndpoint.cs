using Newtonsoft.Json;
using PappionMobile.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Endpoints.Services
{
    public class PostEndpoint
   {
        private const string postsUrl = "https://pappionapi.loca.lt/api/Posts"; 

        public async Task<List<PostModel>> GetAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{postsUrl}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            List<PostModel> list = JsonConvert.DeserializeObject<List<PostModel>>(result.ToString());

            return list;
        }

        public async Task<PostModel> GetAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{postsUrl}/GetById/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            PostModel post = JsonConvert.DeserializeObject<PostModel>(result.ToString());

            return post;
        }

        public async Task<PostCreateModel> CreateAsync(PostCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync($"{postsUrl}/Add", data);
            var result = await response.Content.ReadAsStringAsync();
            PostCreateModel post = JsonConvert.DeserializeObject<PostCreateModel>(result.ToString());
            return post;
        }

        public async Task<PostCreateModel> UpdateAsync(PostCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PutAsync($"{postsUrl}/Update", data);
            var result = await response.Content.ReadAsStringAsync();
            PostCreateModel post = JsonConvert.DeserializeObject<PostCreateModel>(result.ToString());
            return post;
        }

        public async Task DeleteAsync(string Id)
        {
            using var client = new HttpClient();
            var uri = Path.Combine( postsUrl, $"Remove/{Id}");
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

    }
}
