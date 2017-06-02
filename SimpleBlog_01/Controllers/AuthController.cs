using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog_01.ViewModels;
using System.Web.Security;

namespace SimpleBlog_01.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }

        public ActionResult Login()
        {
            return View(new AuthLogin
            {
            });
        }

        //this attribute makes this method only take POST requests
        //so GET requests are handled by method above
        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(form);

            FormsAuthentication.SetAuthCookie(form.Username, true);

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("home");
        }
    }
}