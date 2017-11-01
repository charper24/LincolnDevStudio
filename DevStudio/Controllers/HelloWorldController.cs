using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStudio.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        //
        //GET: /HelloWorld/Welcom/

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}