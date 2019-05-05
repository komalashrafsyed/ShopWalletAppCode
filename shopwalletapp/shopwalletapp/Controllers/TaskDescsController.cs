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
    public class TaskDescsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskDescs
        public ActionResult Index()
        {
            ViewBag.topheadding = "Task Description";
            return View(db.TaskDescs.ToList());
        }

        // GET: TaskDescs/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.topheadding = "Task Description Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDesc taskDesc = db.TaskDescs.Find(id);
            if (taskDesc == null)
            {
                return HttpNotFound();
            }
            return View(taskDesc);
        }

        // GET: TaskDescs/Create
        public ActionResult Create()
        {
            ViewBag.topheadding = "Task Description Create";
            return View();
        }

        // POST: TaskDescs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TaskDesc taskDesc)
        {
            ViewBag.topheadding = "Task Description Create";
            if (ModelState.IsValid)
            {
                db.TaskDescs.Add(taskDesc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskDesc);
        }

        // GET: TaskDescs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.topheadding = "Task Description Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDesc taskDesc = db.TaskDescs.Find(id);
            if (taskDesc == null)
            {
                return HttpNotFound();
            }
            return View(taskDesc);
        }

        // POST: TaskDescs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TaskDesc taskDesc)
        {
            ViewBag.topheadding = "Task Description Edit";
            if (ModelState.IsValid)
            {
                db.Entry(taskDesc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskDesc);
        }

        // GET: TaskDescs/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.topheadding = "Task Description Delete Confirm";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDesc taskDesc = db.TaskDescs.Find(id);
            if (taskDesc == null)
            {
                return HttpNotFound();
            }
            return View(taskDesc);
        }

        // POST: TaskDescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.topheadding = "Task Description Delete Confirm";
            TaskDesc taskDesc = db.TaskDescs.Find(id);
            db.TaskDescs.Remove(taskDesc);
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
