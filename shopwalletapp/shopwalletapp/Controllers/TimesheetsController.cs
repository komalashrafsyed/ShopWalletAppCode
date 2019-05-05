using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopwalletapp.Models;

namespace shopwalletapp.Controllers
{
    public class TimesheetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Timesheets
        public ActionResult Index()
        {
            ViewBag.topheadding = "Time sheets";
            var timesheets = db.Timesheets.Include(t => t.Employee).Include(t => t.Employee1).Include(t => t.TaskDesc);
            return View(timesheets.ToList());
        }

        // GET: Timesheets/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.topheadding = "Time sheets Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Include(t => t.Employee).Include(t => t.Employee1).Include(t => t.TaskDesc).FirstOrDefault(e=>e.Id == id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // GET: Timesheets/Create
        public ActionResult Create()
        {
            ViewBag.topheadding = "Time sheets Create";
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email");
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "Email");
            ViewBag.TaskDescId = new SelectList(db.TaskDescs, "Id", "Name");
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,ManagerId,Date,Hours,HourlyRate,TaskDescId")] Timesheet timesheet)
        {
            ViewBag.topheadding = "Time sheets Create";
            if (ModelState.IsValid)
            {
                db.Timesheets.Add(timesheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", timesheet.EmployeeId);
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "Email", timesheet.ManagerId);
            ViewBag.TaskDescId = new SelectList(db.TaskDescs, "Id", "Name", timesheet.TaskDescId);
            return View(timesheet);
        }

        // GET: Timesheets/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.topheadding = "Time sheets Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", timesheet.EmployeeId);
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "Email", timesheet.ManagerId);
            ViewBag.TaskDescId = new SelectList(db.TaskDescs, "Id", "Name", timesheet.TaskDescId);
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,ManagerId,Date,Hours,HourlyRate,TaskDescId")] Timesheet timesheet)
        {
            ViewBag.topheadding = "Time sheets Edit";
            if (ModelState.IsValid)
            {
                db.Entry(timesheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", timesheet.EmployeeId);
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "Email", timesheet.ManagerId);
            ViewBag.TaskDescId = new SelectList(db.TaskDescs, "Id", "Name", timesheet.TaskDescId);
            return View(timesheet);
        }

        // GET: Timesheets/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.topheadding = "Time sheets Delete Confirm";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = db.Timesheets.Include(t => t.Employee).Include(t => t.Employee1).Include(t => t.TaskDesc).FirstOrDefault(e=>e.Id==id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.topheadding = "Time sheets Delete Confirm";
            Timesheet timesheet = db.Timesheets.Find(id);
            db.Timesheets.Remove(timesheet);
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
