using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Troiamis.Models;
using Troiamis.ModelsCombined;

namespace Troiamis.Controllers
{
    public class HomeController : Controller
    {
        private readonly TroiamisDBContext DB;

        public HomeController(TroiamisDBContext dbcontext)
        {
            this.DB = dbcontext;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckUser()
        {
            ModelsCombined.User user = DB.Users.Where(u => u.userName == Request.Form["userName"] && u.password == Request.Form["password"]).FirstOrDefault();
            Debug.WriteLine(Request.Form["userName"].ToString());
            Debug.WriteLine(Request.Form["password"].ToString());
            HttpContext.Session.SetString("username", Request.Form["userName"].ToString());
            if (user != null)
            {
                
            }
            else
            {
                RedirectToAction("Login");
            }
            
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}