using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    ///     This controller will set the culture information
    /// </summary>
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult Set(string uiCulture, string returnUrl)
        {
            var feature =
                HttpContext.Features.Get<IRequestCultureFeature>();

            var requestCulture =
                new RequestCulture(feature.RequestCulture.Culture,
                    new CultureInfo(uiCulture));

            var cookieValue =
                CookieRequestCultureProvider.MakeCookieValue(requestCulture);

            var cookieName =
                CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(cookieName, cookieValue);

            return LocalRedirect(returnUrl);
        }
    }
}