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
    public class ChoresController : Controller
    {
        private TaskaEntities db = new TaskaEntities();

        // GET: Chores
        public ActionResult Index()
        {
            var chores = db.Chores.Include(c => c.Category);
            return View(chores.ToList());
        }

        // GET: Chores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            return View(chore);
        }

        // GET: Chores/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Chores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskTitle,TaskDescription,TaskCategory")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Chores.Add(chore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.Categories, "CategoryID", "CategoryName", chore.TaskID);
            return View(chore);
        }

        // GET: Chores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.Categories, "CategoryID", "CategoryName", chore.TaskID);
            return View(chore);
        }

        // POST: Chores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskTitle,TaskDescription,TaskCategory")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.Categories, "CategoryID", "CategoryName", chore.TaskID);
            return View(chore);
        }

        // GET: Chores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chore chore = db.Chores.Find(id);
            if (chore == null)
            {
                return HttpNotFound();
            }
            return View(chore);
        }

        // POST: Chores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chore chore = db.Chores.Find(id);
            db.Chores.Remove(chore);
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
