using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using MongoDB.Bson;
using BLL;
using Model;
 
namespace Assignment2.Controllers
{
    public class GenresController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private GenreBLL _genreBLL = new GenreBLL();

        // GET: Genres
        public ActionResult Index()
        {
            return View(_genreBLL.GetGenres());
        }

        // GET: Genres/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _genreBLL.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreBLL.CreateGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _genreBLL.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Genre genre)
        {
            genre.Id = new ObjectId(id);
            _genreBLL.UpdateGenre(genre);
            return RedirectToAction("Index");

        }

        // GET: Genres/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _genreBLL.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _genreBLL.DeleteGenre(id);
            return RedirectToAction("Index");
        }

        //// GET: Genres/Create
        //public ActionResult Search()
        //{
        //    return View();
        //}

        // GET: Genres/Search/5
        public ActionResult Search(string genreName)
        {
            //if (genreName == "")
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Genre genre = _genreBLL.GetGenreByName(genreName);
            if (genre == null)
            {
                return RedirectToAction("Index");
            }
            return View(genre);
        }



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
