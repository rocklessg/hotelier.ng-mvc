using hotel_booking_model.commons;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class HttpRequestFactory : IHttpRequestFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _url;
        public HttpRequestFactory(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
            _url = configuration.GetSection("BaseURL").Value;

        }

        public async Task<TRes> GetRequestAsync<TRes>(string url, string baseUrl = null) where TRes : class
        {
            var client = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return await GetResponseResultAsync<TRes>(client, request);
        }
        public async Task<TRes> PostRequestAsync<TReq, TRes>(string url, TReq content, string baseUrl = null) where TRes : class where TReq : class
        {
            var client = CreateClient();
            var reqContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = reqContent };
            return await GetResponseResultAsync<TRes>(client, request);
        }
        public async Task<TRes> UpdateRequestAsync<TReq, TRes>(string url, TReq content, string baseUrl = null) where TRes : class where TReq : class
        {
            var client = CreateClient();
            var reqContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = reqContent };
            return await GetResponseResultAsync<TRes>(client, request);
        }

        public async Task<TRes> DeleteRequestAsync<TRes>(string url, string baseUrl = null) where TRes : class
        {
            var client = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            return await GetResponseResultAsync<TRes>(client, request);
        }

        public async Task<TRes> UploadFileAsync<TReq, TRes>(string url, TReq file, string baseUrl = null) where TReq : IFormFile where TRes : class
        {
            var client = CreateClient();
            var form = new MultipartFormDataContent();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, nameof(file), file.FileName);
            }
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = form };
            return await GetResponseResultAsync<TRes>(client, request);
        }

        private async Task<TRes> GetResponseResultAsync<TRes>(HttpClient client, HttpRequestMessage request) where TRes : class
        {
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TRes>(responseString);
            return result;
        }
        private HttpClient CreateClient() { 
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_url);
            var token = _httpContextAccessor.HttpContext.Session.GetString("access_token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpContextAccessor.HttpContext.Request.Headers.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
    }
}
