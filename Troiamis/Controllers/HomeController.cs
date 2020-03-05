using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            if (HttpContext.Session.GetString("username") == "" || HttpContext.Session.GetString("username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("HomePage");
            }
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                user.avatarImageString = "";
                User isExisting = DB.Users.Select(u => u).Where(u => u.userName == user.userName).FirstOrDefault();
                if (isExisting != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    HttpContext.Session.SetString("username", user.userName.ToString());
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            string user = HttpContext.Session.GetString("username");
            if (user != null)
            {
                if (user == DB.Users.Where(u => u.userName == user).FirstOrDefault().userName)
                {
                    return View();
                }            
            }

            return RedirectToAction("Login");

            //if (user == null || HttpContext.Session.GetString(user.userName) == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //else
            //{
                
            //}

            //return View();
        }

        [HttpPost]
        public IActionResult NewPost(ModelsCombined.Post outgoingPost)
        {
            outgoingPost.fileName = "NULL";
            outgoingPost.posterName = HttpContext.Session.GetString("username");
            outgoingPost.timeStamp = DateTime.Now;
            outgoingPost.postID = DB.Posts.Count() + 1;
            outgoingPost.ratings = 1;
            if (outgoingPost.postTitle != null && outgoingPost.postContent != null)
            {
                DB.Posts.Add(outgoingPost);
                DB.SaveChanges();

                return RedirectToAction("ViewPost", new { id = outgoingPost.postID });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewPost(long id)
        {

            ViewData["Post"] = DB.Posts.Where(p => p.postID == id).FirstOrDefault();
            ViewData["Comments"] = DB.Comments.Where(c => c.postID == id).ToList();

            return View();
        }

        public IActionResult HomePage()
        {
            List<Post> recent = DB.Posts.OrderBy(p => p.timeStamp).Take(10).ToList();
            return View(recent);
        }

        public IActionResult Gallery()
        {
            return View(DB.Posts.Select(p => p));
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [HttpPost]
        public IActionResult Login(ModelsCombined.User compare)
        {
            ModelsCombined.User user = DB.Users.Where(u => u.userName == compare.userName && u.password == compare.password).FirstOrDefault();

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

        public IActionResult Profile(string profileName)
        {
            ModelsCombined.User user = DB.Users.Where(u => u.userName == profileName).FirstOrDefault();

            IEnumerable<Post> userPosts = DB.Posts.Where(u => u.posterName == profileName);

            return View(userPosts);
        }

        [HttpPost]
        public IActionResult Comment()
        {
            
        }
    }
}