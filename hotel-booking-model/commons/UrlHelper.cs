using Microsoft.AspNetCore.Http;

namespace hotel_booking_model.commons
{
    public class UrlHelper
    {
        public static string CreateUrl(string urlPath, HttpContext context)
        {
            return string.Join('/', BaseAddress(context), urlPath);
        }
 
        public static string BaseAddress(HttpContext context)
        {
            return context.Request.Scheme + "://" + context.Request.Host;
        }

    }
}
