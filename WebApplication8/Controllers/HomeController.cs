using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult FormDemo()
        {
            return View();
        }

        public ActionResult FormSubmit(string firstName, string lastName)
        {
            return View(new FormSubmissionViewModel
            {
                FirstName = firstName,
                LastName = lastName
            });
        }
    }
}