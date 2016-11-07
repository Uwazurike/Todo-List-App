using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoListApp;

namespace ToDoListApp.Controllers
{
    public class TaskRecordsController : Controller
    {
        private TaskaEntities db = new TaskaEntities();

        // GET: TaskRecords
        public ActionResult Index()
        {
            var taskRecords = db.TaskRecords.Include(t => t.Chore);
            return View(taskRecords.ToList());
        }

        // GET: TaskRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskRecord taskRecord = db.TaskRecords.Find(id);
            if (taskRecord == null)
            {
                return HttpNotFound();
            }
            return View(taskRecord);
        }

        // GET: TaskRecords/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.Chores, "TaskID", "TaskTitle");
            return View();
        }

        // POST: TaskRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,TaskID,UserID,DateCreated,DueDate,DateCompleted")] TaskRecord taskRecord)
        {
            if (ModelState.IsValid)
            {
                db.TaskRecords.Add(taskRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.Chores, "TaskID", "TaskTitle", taskRecord.TaskID);
            return View(taskRecord);
        }

        // GET: TaskRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskRecord taskRecord = db.TaskRecords.Find(id);
            if (taskRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.Chores, "TaskID", "TaskTitle", taskRecord.TaskID);
            return View(taskRecord);
        }

        // POST: TaskRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,TaskID,UserID,DateCreated,DueDate,DateCompleted")] TaskRecord taskRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.Chores, "TaskID", "TaskTitle", taskRecord.TaskID);
            return View(taskRecord);
        }

        // GET: TaskRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskRecord taskRecord = db.TaskRecords.Find(id);
            if (taskRecord == null)
            {
                return HttpNotFound();
            }
            return View(taskRecord);
        }

        // POST: TaskRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskRecord taskRecord = db.TaskRecords.Find(id);
            db.TaskRecords.Remove(taskRecord);
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
