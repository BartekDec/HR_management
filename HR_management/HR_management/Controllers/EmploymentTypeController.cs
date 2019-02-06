using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Interfaces;
using HR_management.ControllersInterfaces;

namespace HR_management.Controllers
{
    public class EmploymentTypeController : Controller
    {
        private readonly IEmploymentTypeComponents _employmentTypeComponent;
        private readonly IHrContext _context;

        public EmploymentTypeController( IEmploymentTypeComponents employmentTypeComponent, IHrContext context)
        {
            _context = context;
            _employmentTypeComponent = employmentTypeComponent;
        }
        // GET: EmploymentType
        public ActionResult Index()
        {
            var empType = _employmentTypeComponent.GetEmploymentType();
            return View(empType);
        }

        // GET: EmploymentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType employmentType = _employmentTypeComponent.GetEmploymentTypeById((int)id);
            if (employmentType == null)
            {
                return HttpNotFound();
            }
            return View(employmentType);
        }

        // GET: EmploymentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmploymentType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tax,EmpTypeName")] EmploymentType employmentType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employmentTypeComponent.AddEmploymentType(employmentType);
                    _employmentTypeComponent.SaveChnages();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(employmentType);
                }
        
            }

            return View(employmentType);
        }

        // GET: EmploymentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType employmentType = _employmentTypeComponent.GetEmploymentTypeById((int)id);
            if (employmentType == null)
            {
                return HttpNotFound();
            }
            return View(employmentType);
        }

        // POST: EmploymentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tax,EmpTypeName")] EmploymentType employmentType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employmentTypeComponent.Actualize(employmentType);
                    _employmentTypeComponent.SaveChnages();
                }
                catch
                {
                    return RedirectToAction("Index");
                }
     
                return RedirectToAction("Index");
            }
            return View(employmentType);
        }

        // GET: EmploymentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmploymentType employmentType = _employmentTypeComponent.GetEmploymentTypeById((int)id);
            if (employmentType == null)
            {
                return HttpNotFound();
            }
            return View(employmentType);
        }

        // POST: EmploymentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employmentTypeComponent.DeleteEmploymentType(id);
            try
            {
                _employmentTypeComponent.SaveChnages();
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
