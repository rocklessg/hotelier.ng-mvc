using hotel_booking_model.commons;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hotel_booking_mvc.Controllers
{
   
    public class ErrorsController : Controller
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("/Error/{statusCode}")]
        public IActionResult Error401(int statusCode)
        {

            switch (statusCode)
            {
                case 404:
                    var statusDetails = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                    var path = statusDetails.OriginalPath;
                    var qString = statusDetails.OriginalQueryString;
                    // Todo: log error to file
                    _logger.LogError(path, qString);
                    break;

                case 401:
                    var statusDetail = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                    var paths = statusDetail.OriginalPath;
                    var currentPath = UrlHelper.CreateUrl("Account/Login", HttpContext);
                    var returnUrl = $"{currentPath}?returnUrl={paths}";
                    return Redirect(returnUrl);

            }
            return View();
        }
        public IActionResult Error404(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    var statusDetails = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                    var path = statusDetails.OriginalPath;
                    var qString = statusDetails.OriginalQueryString;
                    // Todo: log error to file
                    _logger.LogError(path, qString);
                    break;
            }
            return View();
        }
        public IActionResult Error500()
        {
            var errorDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var path = errorDetails.Path;
            var err = errorDetails.Error;
            // Todo: log to file
            _logger.LogError(err, path);
            return View();
        }
    }
}
