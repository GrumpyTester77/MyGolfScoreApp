using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyGolfScoreApp.Data;
using MyGolfScoreApp.Models;

namespace MyGolfScoreApp.Controllers
{
    public class CourseViewModelsController : Controller
    {
        private MyGolfScoreAppDb db = new MyGolfScoreAppDb();

        // GET: CourseViewModels
        public ActionResult Index()
        {
            return View(db.Course.ToList());
        }

        // GET: CourseViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseViewModel courseViewModel = db.Course.Find(id);
            if (courseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(courseViewModel);
        }

        // GET: CourseViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(courseViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        // GET: CourseViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseViewModel courseViewModel = db.Course.Find(id);
            if (courseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(courseViewModel);
        }

        // POST: CourseViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseViewModel);
        }

        // GET: CourseViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseViewModel courseViewModel = db.Course.Find(id);
            if (courseViewModel == null)
            {
                return HttpNotFound();
            }
            return View(courseViewModel);
        }

        // POST: CourseViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseViewModel courseViewModel = db.Course.Find(id);
            db.Course.Remove(courseViewModel);
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
    }
}
