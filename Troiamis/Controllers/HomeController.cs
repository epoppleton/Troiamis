using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            Post P = new Post { fileName = "Test", posterName = "Test", postTitle = "Test", postContent = "This is a test", timeStamp = DateTime.Now, postID = 1, ratings = 1 };
            DB.Posts.Add(P);
            DB.SaveChanges();

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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}