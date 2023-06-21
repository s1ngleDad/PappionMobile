using Newtonsoft.Json;
using PappionMobile.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PappionMobile.Endpoints.PappionBackend
{
    public class ReportEndpoint
    {
        private const string reportsUrl = "";

        public async Task<List<ReportModel>> GetAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync(reportsUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            List<ReportModel> list = JsonConvert.DeserializeObject<List<ReportModel>>(result.ToString());

            return list;
        }

        public async Task<ReportModel> GetAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client
                .GetAsync($"{reportsUrl}/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(responseBody);

            ReportModel report = JsonConvert.DeserializeObject<ReportModel>(result.ToString());

            return report;
        }

        public async Task<ReportModel> CreateAsync(ReportModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(reportsUrl, data);
            var result = await response.Content.ReadAsStringAsync();
            ReportModel report = JsonConvert.DeserializeObject<ReportModel>(result.ToString());
            return report;
        }

        public async Task<ReportModel> UpdateAsync(ReportModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PutAsync(reportsUrl, data);
            var result = await response.Content.ReadAsStringAsync();
            ReportModel report = JsonConvert.DeserializeObject<ReportModel>(result.ToString());
            return report;
        }

        public async Task DeleteAsync(int Id)
        {
            using var client = new HttpClient();
            var uri = Path.Combine(reportsUrl, $"{Id}");
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
