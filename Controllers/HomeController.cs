using BlogPl.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BlogPl.Controllers
{
    public class HomeController : Controller
    {
        public class BlogWithComments
        {

            public List<Blog> Blogs { get; set; }
            public List<Comment> Comments { get; set; }
        }
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                Dictionary<int, List<Comment>> blogComments = new Dictionary<int, List<Comment>>();

                var blogPosts = db.Blogs.OrderByDescending(i => i.id).ToList();
                
                return View(blogPosts);
            }
                
        }

        public ActionResult Details(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var blog = db.Blogs.Find(id);

                if (blog == null)
                {
                    return HttpNotFound();
                }

                // Retrieve all comments with the specified blog_id
                var comments = db.Comments.Where(c => c.blog_id == id).OrderByDescending(i => i.id).ToList();

                // Create a ViewModel to hold the blog and its comments
                var viewModel = new BlogWithCommentsViewModel
                {
                    Blog = blog,
                    Comments = comments
                };

                return View(viewModel);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}