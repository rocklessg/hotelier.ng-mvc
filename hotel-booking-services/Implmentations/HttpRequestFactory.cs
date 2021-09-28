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

        public async Task<TRes> GetRequestAsync<TRes>(string url, string baseUrl = null) where TRes : BasicResponse<TRes>
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            return await GetResponseResultAsync<TRes>(response);
            //var responseString = await response.Content.ReadAsStringAsync();
            //result.Data = JsonConvert.DeserializeObject<TRes>(responseString);
            //result.StatusCode = (int)response.StatusCode;
            //result.Success = response.IsSuccessStatusCode;
            //return result;
        }
        public async Task<TRes> PostRequestAsync<TReq, TRes>(string url, TReq content, string baseUrl = null) where TRes : BasicResponse<TRes> where TReq : class
        {
            var client = CreateClient(baseUrl);
            var reqContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = reqContent };
            var response = await client.SendAsync(request);
            return await GetResponseResultAsync<TRes>(response);
        }

        public async Task<TRes> DeleteRequestAsync<TRes>(string url, string baseUrl = null) where TRes : BasicResponse<TRes>
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await client.SendAsync(request);
            return await GetResponseResultAsync<TRes>(response);
        }

        public async Task<TRes> UploadFileAsync<TReq, TRes>(string url, TReq file, string baseUrl = null) where TReq : IFormFile where TRes : BasicResponse<TRes>
        {
            var client = CreateClient(baseUrl);
            var form = new MultipartFormDataContent();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, nameof(file), file.FileName);
            }
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = form };
            using var response = await client.SendAsync(httpRequestMessage);
            return await GetResponseResultAsync<TRes>(response);
        }

        //private async Task<BasicResponse<TRes>> GetResponseResultAsync<TRes>(HttpResponseMessage response)
        //{
        //    var responseString = await response.Content.ReadAsStringAsync();
        //    BasicResponse<TRes> result = JsonConvert.DeserializeObject<BasicResponse<TRes>>(responseString);
        //    return result;
        //}
        private async Task<TRes> GetResponseResultAsync<TRes>(HttpResponseMessage response) where TRes : BasicResponse<TRes>
        {
            var responseString = await response.Content.ReadAsStringAsync();
            TRes result = JsonConvert.DeserializeObject<TRes>(responseString);
            return result;
        }

        private HttpClient CreateClient(string baseUrl = null)
        {
            baseUrl ??= _url;
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(baseUrl);
            var token = _httpContextAccessor.HttpContext.Session.GetString("access_token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpContextAccessor.HttpContext.Request.Headers.Add("Authorization", "Bearer " + token);
            }
            return client;
        }
    }
}
