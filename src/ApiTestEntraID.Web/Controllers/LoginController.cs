using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestEntraID.Web.Controllers;

[AllowAnonymous]
public sealed class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
    }

    [HttpGet]
    public IActionResult Logout()
    {
        var props = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(HomeController.Index), "Home")
        };

        return SignOut(
            props,
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme);
    }
}