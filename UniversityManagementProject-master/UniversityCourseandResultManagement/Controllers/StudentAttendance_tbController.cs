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
    public class StudentAttendance_tbController : Controller
    {
        private SMSEntities db = new SMSEntities();

        // GET: StudentAttendance_tb
        public ActionResult Index()
        {
            var studentAttendance_tb = db.StudentAttendance_tb.Include(s => s.Student_tb);
            return View(studentAttendance_tb.ToList());
        }

        // GET: StudentAttendance_tb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance_tb studentAttendance_tb = db.StudentAttendance_tb.Find(id);
            if (studentAttendance_tb == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance_tb);
        }

        // GET: StudentAttendance_tb/Create
        public ActionResult Create()
        {
            ViewBag.Std_id = new SelectList(db.Student_tb, "Id", "StudentName");
            return View();
        }

        // POST: StudentAttendance_tb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,AttendanceStatus,Std_id")] StudentAttendance_tb studentAttendance_tb)
        {
            if (ModelState.IsValid)
            {
                db.StudentAttendance_tb.Add(studentAttendance_tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Std_id = new SelectList(db.Student_tb, "Id", "StudentName", studentAttendance_tb.Std_id);
            return View(studentAttendance_tb);
        }

        // GET: StudentAttendance_tb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance_tb studentAttendance_tb = db.StudentAttendance_tb.Find(id);
            if (studentAttendance_tb == null)
            {
                return HttpNotFound();
            }
            ViewBag.Std_id = new SelectList(db.Student_tb, "Id", "StudentName", studentAttendance_tb.Std_id);
            return View(studentAttendance_tb);
        }

        // POST: StudentAttendance_tb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,AttendanceStatus,Std_id")] StudentAttendance_tb studentAttendance_tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendance_tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Std_id = new SelectList(db.Student_tb, "Id", "StudentName", studentAttendance_tb.Std_id);
            return View(studentAttendance_tb);
        }

        // GET: StudentAttendance_tb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance_tb studentAttendance_tb = db.StudentAttendance_tb.Find(id);
            if (studentAttendance_tb == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance_tb);
        }

        // POST: StudentAttendance_tb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendance_tb studentAttendance_tb = db.StudentAttendance_tb.Find(id);
            db.StudentAttendance_tb.Remove(studentAttendance_tb);
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
