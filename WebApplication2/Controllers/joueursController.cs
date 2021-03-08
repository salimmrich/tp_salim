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
    public class joueursController : Controller
    {
        private gestion_equipeEntities db = new gestion_equipeEntities();

        // GET: joueurs
        public ActionResult Index()
        {
            var joueur = db.joueur.Include(j => j.equipe);
            return View(joueur.ToList());
        }

        // GET: joueurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueur joueur = db.joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // GET: joueurs/Create
        public ActionResult Create()
        {
            ViewBag.joueur_fk_equipe_id = new SelectList(db.equipe, "equipe_id", "equipe_lib");
            return View();
        }

        // POST: joueurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "joueur_id,Joueur_nom,joueur_prenom,age,joueur_fk_equipe_id")] joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.joueur.Add(joueur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.joueur_fk_equipe_id = new SelectList(db.equipe, "equipe_id", "equipe_lib", joueur.joueur_fk_equipe_id);
            return View(joueur);
        }

        // GET: joueurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueur joueur = db.joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            ViewBag.joueur_fk_equipe_id = new SelectList(db.equipe, "equipe_id", "equipe_lib", joueur.joueur_fk_equipe_id);
            return View(joueur);
        }

        // POST: joueurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "joueur_id,Joueur_nom,joueur_prenom,age,joueur_fk_equipe_id")] joueur joueur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joueur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.joueur_fk_equipe_id = new SelectList(db.equipe, "equipe_id", "equipe_lib", joueur.joueur_fk_equipe_id);
            return View(joueur);
        }

        // GET: joueurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueur joueur = db.joueur.Find(id);
            if (joueur == null)
            {
                return HttpNotFound();
            }
            return View(joueur);
        }

        // POST: joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            joueur joueur = db.joueur.Find(id);
            db.joueur.Remove(joueur);
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
