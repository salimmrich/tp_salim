using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class stadesController : Controller
    {
        private gestion_equipeEntities db = new gestion_equipeEntities();

        // GET: stades
        public ActionResult Index()
        {
            var stade = db.stade.Include(s => s.Ville);
            return View(stade.ToList());
        }

        // GET: stades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stade stade = db.stade.Find(id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            return View(stade);
        }

        // GET: stades/Create
        public ActionResult Create()
        {
            ViewBag.fk_ville_id = new SelectList(db.Ville, "ville_id", "ville_lib");
            return View();
        }

        // POST: stades/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stade_id,stade_nom,fk_ville_id")] stade stade)
        {
            if (ModelState.IsValid)
            {
                db.stade.Add(stade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_ville_id = new SelectList(db.Ville, "ville_id", "ville_lib", stade.fk_ville_id);
            return View(stade);
        }

        // GET: stades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stade stade = db.stade.Find(id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_ville_id = new SelectList(db.Ville, "ville_id", "ville_lib", stade.fk_ville_id);
            return View(stade);
        }

        // POST: stades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stade_id,stade_nom,fk_ville_id")] stade stade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_ville_id = new SelectList(db.Ville, "ville_id", "ville_lib", stade.fk_ville_id);
            return View(stade);
        }

        // GET: stades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stade stade = db.stade.Find(id);
            if (stade == null)
            {
                return HttpNotFound();
            }
            return View(stade);
        }

        // POST: stades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stade stade = db.stade.Find(id);
            db.stade.Remove(stade);
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
