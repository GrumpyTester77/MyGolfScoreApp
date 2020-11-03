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
    public class HoleViewModelsController : Controller
    {
        private MyGolfScoreAppDb db = new MyGolfScoreAppDb();



        // GET: HoleViewModels
        public ActionResult Index()
        {
            var holeViewModels = db.HoleViewModels.Include(h => h.Course);
            return View(holeViewModels.ToList());
        }

        // GET: HoleViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleViewModel holeViewModel = db.HoleViewModels.Find(id);
            if (holeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(holeViewModel);
        }

        // GET: HoleViewModels/Create
        public ActionResult Create()
        {
            var dbcourse = db.Course.ToList();

            //Make selectlist, which is IEnumerable<SelectListItem>
            var courseNameDropdownList = new SelectList(db.Course.Select(item => new SelectListItem()
            {
                Text = item.CourseName.ToString(),
                Value = item.CourseId.ToString()
            }).ToList(), "Value", "Text");

            // Assign the Selectlist to the View Model   
            var viewCourse = new HoleViewModel()
            {
                Course = dbcourse.FirstOrDefault(),
                // The Dropdownlist values
                CourseNamesDropdownList = courseNameDropdownList,
 
            };

            
            return View(viewCourse);
        }

        // POST: HoleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoleId,HoleNumber,Par,Length,StrokeIndex,CourseId")]  HoleViewModel holeViewModel)
        {
            if (ModelState.IsValid)
            {

                db.HoleViewModels.Add(holeViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(holeViewModel);
        }

        // GET: HoleViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleViewModel holeViewModel = db.HoleViewModels.Find(id);
            if (holeViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.CourseViewModels, "CourseId", "CourseName", holeViewModel.CourseId);
            return View(holeViewModel);
        }

        // POST: HoleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoleId,HoleNumber,Par,Length,StrokeIndex,CourseId")] HoleViewModel holeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holeViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.CourseViewModels, "CourseId", "CourseName", holeViewModel.CourseId);
            return View(holeViewModel);
        }

        // GET: HoleViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleViewModel holeViewModel = db.HoleViewModels.Find(id);
            if (holeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(holeViewModel);
        }

        // POST: HoleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoleViewModel holeViewModel = db.HoleViewModels.Find(id);
            db.HoleViewModels.Remove(holeViewModel);
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
