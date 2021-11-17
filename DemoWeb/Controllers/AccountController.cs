using DemoApp.Model;
using DemoWeb.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DemoWeb.Controllers
{
    public class AccountController : Controller
    {
        MyDemoDbContext _context;
        public AccountController(MyDemoDbContext context)
        {
            this._context = context;
        }
        
        // GET: AccountController/Login
        public ActionResult Login(string returnUrl="")
        {
            TempData["ReturnURL"] = returnUrl;
            return View();
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {

                    UserProfile user = _context.userProfiles.Where(u => u.EmailId == login.Email).FirstOrDefault();

                if (user != null)
                {
                    try
                    {

                        if (PasswordHashSecurity.VerifyPassword(login.Password, user.Password))
                        {
                            login.RememberMe = true;
                            List<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name,user.UserName),
                                new Claim(ClaimTypes.Email,user.EmailId),
                                new Claim("PKId",user.PkUserId.ToString()),
                                new Claim("Image",user.Image)
                            };
                            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                            HttpContext.SignInAsync(principal, new AuthenticationProperties()
                            {
                                IsPersistent = login.RememberMe,
                                IssuedUtc = DateTime.UtcNow

                            });
                            string returnURL = TempData["ReturnURL"].ToString();
                            if (!string.IsNullOrEmpty(returnURL))
                                return Redirect(returnURL);
                            else if (string.IsNullOrEmpty(returnURL))
                                return RedirectToAction("Index", "UserProfile");

                            else
                                return Unauthorized();
                        }
                    }
                    catch (Exception ex)
                    {
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Inavalid UserName or Password");
                }
            }
            return View();
        }

        //AccountController/LogOut
        public ActionResult LogOut()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
