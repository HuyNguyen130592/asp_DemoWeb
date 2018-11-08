using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_web.Controllers
{
    public class demoController : Controller
    {
        // GET: demo
        public ActionResult Index()
        {
            int[] abc = new int[] {1,2,3,4,5,6 };
            List<int> query = abc.Where(n => n > 3&&n<5).ToList();
            string[] abs = new string[] {"ab01","ab02","ab03","ab04" };
            
            return View(query);
        }
    }
}