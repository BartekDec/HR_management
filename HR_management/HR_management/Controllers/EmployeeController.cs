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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeComponents _employeeComponent;
        private readonly IHrContext _context;
        public EmployeeController(IHrContext context, IEmployeeComponents employeeComponent)
        {
            _employeeComponent = employeeComponent;
            _context = context;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employee = _employeeComponent.GetEmployee();
            // var employee = db.Employee.Include(e => e.Salary);
            return View(employee);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeComponent.GetEmployeeById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.SalaryId = new SelectList(_context.Salary, "Id", "Currency");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,PhoneNumber,Email,SalaryId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeComponent.AddEmployee(employee);
                    _employeeComponent.SaveChnages();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(employee);
                }
        
            }

            ViewBag.SalaryId = new SelectList(_context.Salary, "Id", "Currency", employee.SalaryId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeComponent.GetEmployeeById((int)id);
                if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalaryId = new SelectList(_context.Salary, "Id", "Currency", employee.SalaryId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,PhoneNumber,Email,SalaryId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                  try
                {
                    _employeeComponent.Actualize(employee);
                    _employeeComponent.SaveChnages();
                }
                catch
                {
                    return View(employee);
                }
  
            }
            ViewBag.SalaryId = new SelectList(_context.Salary, "Id", "Currency", employee.SalaryId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeComponent.GetEmployeeById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeComponent.DeleteEmployee(id);
            try
            {
                _employeeComponent.SaveChnages();
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
