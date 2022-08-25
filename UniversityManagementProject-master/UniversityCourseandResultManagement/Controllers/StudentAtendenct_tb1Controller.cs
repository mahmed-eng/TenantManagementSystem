using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement;

namespace UniversityCourseandResultManagement.Controllers
{
    public class StudentAtendenct_tb1Controller : Controller
    {
        private SMSEntities db = new SMSEntities();

        // GET: StudentAtendenct_tb1
        public ActionResult Index()
        {
            var studentAtendenct_tb = db.StudentAtendenct_tb.Include(s => s.Student_tb);
            return View(studentAtendenct_tb.ToList());
        }

        // GET: StudentAtendenct_tb1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAtendenct_tb studentAtendenct_tb = db.StudentAtendenct_tb.Find(id);
            if (studentAtendenct_tb == null)
            {
                return HttpNotFound();
            }
            return View(studentAtendenct_tb);
        }

        // GET: StudentAtendenct_tb1/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Student_tb, "Id", "StudentName");
            return View();
        }

        // POST: StudentAtendenct_tb1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,StudentName,AttendenceDate")] StudentAtendenct_tb studentAtendenct_tb)
        {
            if (ModelState.IsValid)
            {
                db.StudentAtendenct_tb.Add(studentAtendenct_tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Student_tb, "Id", "StudentName", studentAtendenct_tb.StudentId);
            return View(studentAtendenct_tb);
        }

        // GET: StudentAtendenct_tb1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAtendenct_tb studentAtendenct_tb = db.StudentAtendenct_tb.Find(id);
            if (studentAtendenct_tb == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Student_tb, "Id", "StudentName", studentAtendenct_tb.StudentId);
            return View(studentAtendenct_tb);
        }

        // POST: StudentAtendenct_tb1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,StudentName,AttendenceDate")] StudentAtendenct_tb studentAtendenct_tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAtendenct_tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Student_tb, "Id", "StudentName", studentAtendenct_tb.StudentId);
            return View(studentAtendenct_tb);
        }

        // GET: StudentAtendenct_tb1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAtendenct_tb studentAtendenct_tb = db.StudentAtendenct_tb.Find(id);
            if (studentAtendenct_tb == null)
            {
                return HttpNotFound();
            }
            return View(studentAtendenct_tb);
        }

        // POST: StudentAtendenct_tb1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAtendenct_tb studentAtendenct_tb = db.StudentAtendenct_tb.Find(id);
            db.StudentAtendenct_tb.Remove(studentAtendenct_tb);
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
