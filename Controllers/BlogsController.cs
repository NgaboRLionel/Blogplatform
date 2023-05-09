using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPl.Models;

namespace BlogPl.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blogs
        public async Task<ActionResult> Index()
        {
            // Get the current user's name
            string currentUserName = User.Identity.Name;

            // Retrieve the blogs that belong to the current user
            var blogs = await db.Blogs.Where(b => b.owner == currentUserName).OrderByDescending(i => i.id).ToListAsync();
            return View(blogs);
        }

        // GET: Blogs/Details/5
        public async Task<ActionResult> Details(int? id)
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

        //GET: Blogs/Create
       [HttpPost]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,title,description,owner,imageUrls")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(blog);
        }
        // POST: Blogs/Create
        [HttpPost]
        public async Task<ActionResult> SaveBlog(Blog blog)
        {

            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> deleteBlog (int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
            
        

            // GET: Blogs/Edit/5
            public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,title,description,owner,imagesUrl")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
