using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace hotel_booking_mvc.CustomAuthorization
{
    /// <summary>
    /// Custom Authentication Class that overrides the OnActionExecuting Method in ActionFilterAttribute
    /// to provide custom control over how users are authenticated for controllers and action methods. 
    /// </summary>
    public class CustomAuthenticationFilter : ActionFilterAttribute
    {
        private readonly string[] roles;
        public HttpClient Client { get; set; }

        public CustomAuthenticationFilter(params string[] roles)
        {
            this.roles = roles;
            Client = new HttpClient
            {
                BaseAddress = new Uri(Startup.StaticConfig.GetSection("ApiUrl").Value)
            };
            
        }


        /// <summary>
        ///  It's called before the actions decorated with the CustomAuthenticationFilter are executed to check
        ///  if the User have Authorization to Execute such actions.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("access_token");

            if (!string.IsNullOrWhiteSpace(token))
            {
                // If token is not null, it makes an Api call to verify if Logged in User's
                // role/roles is contained in the array of permitted roles.
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                Client.DefaultRequestHeaders.Add("userRole", roles);
                HttpResponseMessage result = Client.GetAsync("api/User/roles").GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    return;
                }
                // If User's role/roles is not contained in the array of permitted roles, it redirects User to the UnAuthorized Page
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "controller", "Authentication" },
                    { "action", "UnAuthorize" }
                    });

            }
            // If token is null, it redirects user to the Login Page
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                { "controller", "Authentication" },
                { "action", "Login" }
                });
        }
    }
 }




