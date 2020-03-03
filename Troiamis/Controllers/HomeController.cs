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

        public IActionResult Login()
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

        public IActionResult ViewPost(ModelsCombined.Post P)
        {
            return View(P);
        }

        public IActionResult HomePage()
        {
            List<Post> recent = DB.Posts.OrderBy(p => p.timeStamp).Take(10).ToList();
            return View(recent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(ModelsCombined.User compare)
        {
            ModelsCombined.User user = DB.Users.Where(u => u.userName == compare.userName && u.password == compare.password).FirstOrDefault();
            Debug.WriteLine(user.userName.ToString());
            Debug.WriteLine(user.password.ToString());

            if (user != null)
            {
                HttpContext.Session.SetString("username", user.userName.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}