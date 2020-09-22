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
using Tp1Mod6.Models;

namespace Tp1Mod6.Controllers
{
    public class SamouraisController : Controller
    {
        private Tp1Mod6Context db = new Tp1Mod6Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel samouraiVM = new SamouraiViewModel();
            samouraiVM.Armes = db.Armes.ToList();
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel samouraiVM)
        {
            if (ModelState.IsValid)
            {
                if (samouraiVM.IdArme != null)
                {
                    samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == samouraiVM.IdArme);
                }
                else
                {
                    samouraiVM.Samourai.Arme = null;
                }                 
                db.Samourais.Add(samouraiVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samouraiVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            SamouraiViewModel samouraiVM = new SamouraiViewModel();
            samouraiVM.Armes = db.Armes.ToList();
            samouraiVM.Samourai = db.Samourais.FirstOrDefault(x => x.Id == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel samouraiVM)
        {
            if (ModelState.IsValid)
            {
                //db.Samourais.Attach(samouraiVM.Samourai); attach mettre la la db tampon

                //chercher ds la db phy et le mettre ds la db partielle pour pouvoir le modifier
                var samouraiToEdit = db.Samourais.Find(samouraiVM.Samourai.Id);
                samouraiToEdit.Force = samouraiVM.Samourai.Force;
                samouraiToEdit.Nom = samouraiVM.Samourai.Nom;
                if (samouraiVM.IdArme != null)
                {
                    samouraiToEdit.Arme = db.Armes.FirstOrDefault(x => x.Id == samouraiVM.IdArme);
                }
                else
                {
                    samouraiToEdit.Arme = null;
                }

                db.Entry(samouraiToEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
