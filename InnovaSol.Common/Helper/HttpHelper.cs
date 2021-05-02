using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSolTest.Common.Helper
{

    public interface IHttpHelper
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync<T>(string url, T model);
    }
    public class HttpHelper : IHttpHelper //IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpHelper(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            AddDefaultRequestHeaders();
        }

        //public void Dispose()
        //{
        //    if (_httpClient != null)
        //        _httpClient.Dispose();
        //}

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        public async Task<string> PostAsync<T>(string url, T model)
        {
            string stringData = JsonConvert.SerializeObject(model);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, contentData).ConfigureAwait(false);
            return response.Content.ReadAsStringAsync().Result;
        }

        private void AddDefaultRequestHeaders()
        {
            var apiBaseUrl = _configuration.GetSection("Api:BaseUrl")?.Value;
            _httpClient.BaseAddress = new Uri(apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
