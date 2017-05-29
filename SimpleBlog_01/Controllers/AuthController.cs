using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog_01.ViewModels;

namespace SimpleBlog_01.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View(new AuthLogin
            {
            });
        }

        //this attribute makes this method only take POST requests
        //so GET requests are handled by method above
        [HttpPost]
        public ActionResult Login(AuthLogin form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            if(form.Username != "Robert Helms")
            {
                ModelState.AddModelError("Username", "You are not Robert Helms!");
                return View(form);
            }

            return Content("The form is valid!");
        }
    }
}