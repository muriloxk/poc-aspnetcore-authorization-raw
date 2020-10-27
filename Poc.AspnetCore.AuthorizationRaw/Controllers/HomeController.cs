using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Poc.AspnetCore.AuthorizationRaw.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        
        public IActionResult Authenticate()
        {
            //RAW LOGIN ASPNET CORE
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Murilo"),
                new Claim(ClaimTypes.Email, "murilando@gmail.com"),
                new Claim("Grandma.Says", "Very nice boy"),
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Murilo Cobre Sanches"),
                new Claim(ClaimTypes.Email, "murilando@gmail.com"),
                new Claim("DrivingLicense", "A+")
            };

            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");
            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
