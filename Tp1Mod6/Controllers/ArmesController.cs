using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOMod6;
using Tp1Mod6.Data;

namespace Tp1Mod6.Controllers
{
    public class ArmesController : Controller
    {
        private Tp1Mod6Context db = new Tp1Mod6Context();

        // GET: Armes
        public ActionResult Index()
        {
            return View(db.Armes.ToList());
        }

        // GET: Armes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // GET: Armes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Degats")] Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Armes.Add(arme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arme);
        }

        // GET: Armes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // POST: Armes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Degats")] Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arme);
        }

        // GET: Armes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arme arme = db.Armes.Find(id);
            //ne pas supprimer si une arme appartient à un samourai
            List<Samourai> samourais = db.Samourais.ToList();

            var samouraisWithWeapon = samourais.Where(x => x.Arme == arme);
            foreach (var item in samouraisWithWeapon)
            {
                item.Arme = null;                   
            }

            db.Armes.Remove(arme);
            db.SaveChanges();
            return RedirectToAction("Index");

            /*Modifier le code de suppression d’une arme pour gérer 
             * le cas d’une arme associée à un samouraï.
             *bool armeFound = false;          
                      foreach (var samourai in samourais)
                       {
                           if (samourai.Arme != null)
                           {
                               if (samourai.Arme.Id == arme.Id)
                               {
                                   armeFound = true;
                                   break;
                               }
                           }
                       }

                       if (!armeFound)
                       {
                           db.Armes.Remove(arme);
                           db.SaveChanges();
                           return RedirectToAction("Index");
                       }
                       else
                       {               
                           return RedirectToAction("Index");
                       }
           */
            /* avec linq
              Arme arme = db.Armes.Find(id);
            List<Samourai> sams = db.Samourais.ToList();
            if (sams.Where(x => x.Arme != null).Any(x => x.Arme == arme))
            {
                return RedirectToAction("Index");
            }
            db.Armes.Remove(arme);
            db.SaveChanges();
            return RedirectToAction("Index");
             */


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
