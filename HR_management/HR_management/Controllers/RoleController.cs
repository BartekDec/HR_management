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
    public class RoleController : Controller
    {
        private readonly IRoleComponents _roleComponent;
        private readonly IHrContext _context;
        public RoleController(IRoleComponents role, IHrContext context )
        {
            _roleComponent = role;
            _context = context;

        }
        // GET: Role
        public ActionResult Index()
        {
            var role = _roleComponent.GetRole();
            return View(role);
        }

        // GET: Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleComponent.GetRoleById((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoleName")] Role role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _roleComponent.AddRole(role);
                    _roleComponent.SaveChnages();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(role);
                }

            }

            return View(role);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleComponent.GetRoleById((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleName")] Role role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _roleComponent.Actualize(role);
                    _roleComponent.SaveChnages();
                }
                catch
                {
                    return View(role);
                }
                //return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleComponent.GetRoleById((int)id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _roleComponent.DeleteRole(id);
            try
            {
                _roleComponent.SaveChnages();
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
