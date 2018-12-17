using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspProject.Controllers
{
    public class HomeController : Controller
    {
        public static Dictionary<string, string> myMenu = new Dictionary<string, string>();
        // GET: Home
        public ActionResult Index()
        {
            return View();    
             }
    }
}