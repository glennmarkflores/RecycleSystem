﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecycleSystem.DAL;
using RecycleSystem.Models;

namespace RecycleSystem.Controllers
{
    public class TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Type
        public ActionResult List()
        {
            return View(db.Types.ToList());
        }

        // GET: Type/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Type/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Type,Rate,MinKg,MaxKg")] TypeModel typeModel)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(typeModel);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(typeModel);
        }

        // GET: Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeModel typeModel = db.Types.Find(id);
            if (typeModel == null)
            {
                return HttpNotFound();
            }
            return View(typeModel);
        }

        // POST: Type/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Rate,MinKg,MaxKg")] TypeModel typeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(typeModel);
        }

        // GET: Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeModel typeModel = db.Types.Find(id);
            if (typeModel == null)
            {
                return HttpNotFound();
            }
            return View(typeModel);
        }

        // POST: Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeModel typeModel = db.Types.Find(id);
            db.Types.Remove(typeModel);
            db.SaveChanges();
            return RedirectToAction("List");
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
