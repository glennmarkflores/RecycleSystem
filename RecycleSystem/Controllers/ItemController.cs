using System;
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
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public ActionResult List()
        {
            var items = db.Items.Include(i => i.TypeModel);
            return View(items.ToList());
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.TypeModelId = new SelectList(db.Types, "Id", "Type");
            return View();
        }

        public ActionResult GetRate(int recyclableTypeId)
        {
            var rate = db.Types.Where(t => t.Id == recyclableTypeId).Select(t => t.Rate).FirstOrDefault();
            return Json(rate, JsonRequestBehavior.AllowGet);
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeModelId,Weight,ComputedRate,ItemDescription")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(itemModel);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            ViewBag.TypeModelId = new SelectList(db.Types, "Id", "Type", itemModel.TypeModelId);
            return View(itemModel);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeModelId = new SelectList(db.Types, "Id", "Type", itemModel.TypeModelId);
            return View(itemModel);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeModelId,Weight,ComputedRate,ItemDescription")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.TypeModelId = new SelectList(db.Types, "Id", "Type", itemModel.TypeModelId);
            return View(itemModel);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel itemModel = db.Items.Find(id);
            db.Items.Remove(itemModel);
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
