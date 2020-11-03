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
    public class RoundViewModelsController : Controller
    {
        private MyGolfScoreAppDb db = new MyGolfScoreAppDb();

        // GET: RoundViewModels
        public ActionResult Index()
        {
            var round = db.Round.Include(r => r.Course);
            return View(round.ToList());
        }

        // GET: RoundViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundViewModel roundViewModel = db.Round.Find(id);
            if (roundViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roundViewModel);
        }

        // GET: RoundViewModels/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName");
            return View();
        }

        // POST: RoundViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoundId,CourseId,HoleScore")] RoundViewModel roundViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Round.Add(roundViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", roundViewModel.CourseId);
            return View(roundViewModel);
        }

        // GET: RoundViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundViewModel roundViewModel = db.Round.Find(id);
            if (roundViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", roundViewModel.CourseId);
            return View(roundViewModel);
        }

        // POST: RoundViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoundId,CourseId,HoleScore")] RoundViewModel roundViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roundViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", roundViewModel.CourseId);
            return View(roundViewModel);
        }

        // GET: RoundViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoundViewModel roundViewModel = db.Round.Find(id);
            if (roundViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roundViewModel);
        }

        // POST: RoundViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoundViewModel roundViewModel = db.Round.Find(id);
            db.Round.Remove(roundViewModel);
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
