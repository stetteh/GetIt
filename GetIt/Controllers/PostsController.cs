using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GetIt.Models;

namespace GetIt.Controllers
{
    public class PostsController : Controller
    {
        private GetItDBContext db = new GetItDBContext();

        // GET: Posts
        public ActionResult Index()
        {
            var model = db.Posts.Select(x => new PostIndexVM()
            {
                AuthorName = x.Author,
                CommentCount = x.Comments.Count,
                Title = x.Title,
                PostId = x.Id,
                SubmitDate = x.PostDate,
                Votes = x.Upvote - x.Downvote
            });
            return View(model);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,Title,Body,PostDate,Upvote,Downvote")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,Title,Body,PostDate,Upvote,Downvote")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
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

        [HttpPost] //up and down vote actions
        public ActionResult Votes(int id, bool up)
        {
            var post = db.Posts.Find(id);
            if (up)
            {
                post.Upvote++;
            }
            else
            {
                post.Downvote++;
            }
            db.SaveChanges();
            return Json((post.Upvote - post.Downvote).ToString());
        }

        public ActionResult CreateComment(int id, string author, string body, DateTime date)
        {
            var post = db.Posts.Find(id);

            post.Comments.Add(new Comment() { Author = author, Body = body, CommentDate = date });
            db.SaveChanges();
            return Content("comment created");
        }

        public ActionResult DisplayComment()
        {
            var model = db.Comments.Select(c => new CommentVM()
            {
                AuthorName = c.Author,
                Body = c.Body,
                SubmitDate = c.CommentDate,
                Votes = c.Upvote - c.Downvote
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public enum Author
    {
        Seth,
        John,
        Daniel,
        Kevin,
        Lucky,
        Tee
    }
}
