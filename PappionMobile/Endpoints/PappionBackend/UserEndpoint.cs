using Newtonsoft.Json;
using PappionMobile.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Endpoints.PappionBackend
{
    public class UserEndpoint
    {
        private const string usersUrl = "https://pappionapi.loca.lt/api/Users";

        public async Task<List<UserModel>> GetAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{usersUrl}/GetAll");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            List<UserModel> list = JsonConvert.DeserializeObject<List<UserModel>>(result.ToString());

            return list;
        }

        public async Task<UserModel> GetAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{usersUrl}/GetById/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            UserModel post = JsonConvert.DeserializeObject<UserModel>(result.ToString());

            return post;
        }

        public async Task<UserCreateModel> CreateAsync(UserCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync($"{usersUrl}/Add", data);
            var result = await response.Content.ReadAsStringAsync();
            UserCreateModel post = JsonConvert.DeserializeObject<UserCreateModel>(result.ToString());
            return post;
        }

        public async Task<UserCreateModel> UpdateAsync(UserCreateModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PutAsync($"{usersUrl}/Update", data);
            var result = await response.Content.ReadAsStringAsync();
            UserCreateModel post = JsonConvert.DeserializeObject<UserCreateModel>(result.ToString());
            return post;
        }

        public async Task DeleteAsync(string Id)
        {
            using var client = new HttpClient();
            var uri = Path.Combine(usersUrl, $"Remove/{Id}");
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<UserModel> RegisterAsync(RegisterModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync($"{usersUrl}/register", data);
            var result = await response.Content.ReadAsStringAsync();
            UserModel post = JsonConvert.DeserializeObject<UserModel>(result.ToString());
            return post;
        }
        public async Task<UserModel> LoginAsync(LoginModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync($"{usersUrl}/login", data);
            var result = await response.Content.ReadAsStringAsync();
            UserModel post = JsonConvert.DeserializeObject<UserModel>(result.ToString());
            return post;
        }
    }
}
