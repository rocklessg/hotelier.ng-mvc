using hotel_booking_model.commons;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IHttpRequestFactory
    {
        Task<TRes> DeleteRequestAsync<TRes>(string url, string baseUrl = null) where TRes : BasicResponse<TRes>;
        Task<TRes> GetRequestAsync<TRes>(string url, string baseUrl = null) where TRes : BasicResponse<TRes>;
        Task<TRes> PostRequestAsync<TReq, TRes>(string url, TReq content, string baseUrl = null)
            where TReq : class
            where TRes : BasicResponse<TRes>;
        Task<TRes> UploadFile<TReq, TRes>(string url, TReq file, string baseUrl = null)
            where TReq : IFormFile
            where TRes : BasicResponse<TRes>;
    }
}