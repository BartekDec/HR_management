using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using HR_management.ControllersInterfaces;
using Repository.Interfaces;

namespace HR_management.Controllers
{
    public class SalaryController : Controller
    {
       
        private readonly ISalaryComponents _salaryComponent;
        private readonly IHrContext _context;

        public SalaryController(ISalaryComponents salaryComponent, IHrContext context)
        {
            _salaryComponent = salaryComponent;
            _context = context;
        }

        // GET: Salary
        public ActionResult Index()
        {
            var salary = _salaryComponent.GetSalary();
            return View(salary);
        }

        // GET: Salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = _salaryComponent.GetSalaryById((int)id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            ViewBag.EmploymentTypeId = new SelectList(_context.EmploymentType, "Id", "EmpTypeName");
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
                try
                {
                    _salaryComponent.AddSalary(salary);
                    _salaryComponent.SaveChnages();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(salary);
                }
        
               
            }

            ViewBag.EmploymentTypeId = new SelectList(_context.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
            return View(salary);
        }

        // GET: Salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = _salaryComponent.GetSalaryById((int)id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmploymentTypeId = new SelectList(_context.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
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
                try
                {
                    _salaryComponent.Actualize(salary);
                    _salaryComponent.SaveChnages();
                }
                catch
                {
                    return View(salary);
                }
           
                //return RedirectToAction("Index");
            }
            ViewBag.EmploymentTypeId = new SelectList(_context.EmploymentType, "Id", "EmpTypeName", salary.EmploymentTypeId);
            return View(salary);
        }

        // GET: Salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salary salary = _salaryComponent.GetSalaryById((int)id);
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
            _salaryComponent.DeleteSalary(id);
            try
            {
                _salaryComponent.SaveChnages();
            }
            catch
            {
                return RedirectToAction("Delete");
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
