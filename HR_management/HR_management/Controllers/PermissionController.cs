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
    public class PermissionController : Controller
    {
        private readonly IPermissionComponents _permissionComponent;
        private readonly IHrContext _context;

        public PermissionController(IPermissionComponents permission, IHrContext context)
        {
            _permissionComponent = permission;
            _context = context;
        }
        // GET: Permission
        public ActionResult Index()
        {
            var perm = _permissionComponent.GetPermission();
            return View(perm);
        }

        // GET: Permission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = _permissionComponent.GetPermissionById((int)id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PermName")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _permissionComponent.AddPermission(permission);
                    _permissionComponent.SaveChnages();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(permission);
                }
            }

            return View(permission);
        }

        // GET: Permission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = _permissionComponent.GetPermissionById((int)id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PermName")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _permissionComponent.Actualize(permission);
                    _permissionComponent.SaveChnages();
                }
                catch
                {
                    return View(permission);
                }
            }
            return View(permission);
        }

        // GET: Permission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = _permissionComponent.GetPermissionById((int)id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _permissionComponent.DeletePermission(id);
            try
            {
                _permissionComponent.SaveChnages();
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
