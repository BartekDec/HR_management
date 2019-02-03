using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;

namespace HR_management.Controllers
{
    public class SalaryController : Controller
    {
        private HrContext db = new HrContext();

        // GET: Salary
        public ActionResult Index()
        {
            var salary = db.Salary.Include(s => s.EmploymentType);
            return View(salary.ToList());
        }

        // GET: Salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salary.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentType, "Id", "EmpTypeName");
            return View();
        }

        // POST: Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Currency,EmploymentTypeId")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Salary.Add(salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
            return View(salary);
        }

        // GET: Salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salary.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
            return View(salary);
        }

        // POST: Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Currency,EmploymentTypeId")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmploymentTypeId = new SelectList(db.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
            return View(salary);
        }

        // GET: Salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = db.Salary.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salary salary = db.Salary.Find(id);
            db.Salary.Remove(salary);
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
