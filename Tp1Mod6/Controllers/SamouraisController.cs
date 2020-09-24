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
            var armes = db.Armes.ToList();
            var listArmeDejaPris = db.Armes.Where(x => db.Samourais.Select(s => s.Arme.Id).Contains(x.Id));
            samouraiVM.Armes = armes.Except(listArmeDejaPris).ToList();
            samouraiVM.ArtMartials = db.ArtMartials.ToList();
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel samouraiVM)
        {
            var armeDejaPris = db.Armes.Where(x => db.Samourais.Select(s => s.Arme.Id).Contains(x.Id));

            if (ModelState.IsValid)
            {
                if (samouraiVM.IdArme != null)
                {
                    samouraiVM.Samourai.Arme = db.Armes.Find(samouraiVM.IdArme);
                }
                else
                {
                    samouraiVM.Samourai.Arme = null;
                }

                if (samouraiVM.IdsArtMartial != null)
                {
                    foreach (var item in samouraiVM.IdsArtMartial)
                    {
                        if (armeDejaPris.Any(a => a.Id == item))
                        {
                            //ModelState.AddModelError("", "Cette arme est déjà prise par un Samouraï.");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            samouraiVM.Samourai.ArtMartials = db.ArtMartials.Where(x => samouraiVM.IdsArtMartial.Contains(x.Id)).ToList();                             
                        }
                    }
                }
                else
                {
                    samouraiVM.Samourai.ArtMartials = null;
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

            samouraiVM.ArtMartials = db.ArtMartials.ToList();
            samouraiVM.Samourai = db.Samourais.Find(id);

            var armes = db.Armes.ToList();
            var listArmeDejaPris = db.Armes.Where(x => db.Samourais.Where(s => s.Id != id).Select(s => s.Arme.Id).Contains(x.Id));
            samouraiVM.Armes = armes.Except(listArmeDejaPris).ToList();
            if (samouraiVM.Samourai.Arme != null)
            {
                samouraiVM.IdArme = samouraiVM.Samourai.Arme.Id;
            }
            if (samouraiVM.Samourai.ArtMartials != null)
            {
                samouraiVM.IdsArtMartial = samouraiVM.Samourai.ArtMartials.Select(x => x.Id).ToList(); 
                
            }

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
                //db.Samourais.Attach(samouraiVM.Samourai); attach mettre ds la db tampon

                //Le include permet de récup le samourai ds la db phy. récup objet en mode eager
                //var samouraiToEdit = db.Samourais.Include.FirstOrDefault((x => x.Id == samouraiVM.Samourai.Id));

                //chercher ds la db phy et le mettre ds la db partielle pour pouvoir le modifier. charge la mémoire
                //Samourai samouraiToEdit = db.Samourais.Find(samouraiVM.Samourai.Id);

                var samouraiToEdit = db.Samourais.Include(s => s.Arme).FirstOrDefault((x => x.Id == samouraiVM.Samourai.Id));
                samouraiToEdit.Force = samouraiVM.Samourai.Force;
                samouraiToEdit.Nom = samouraiVM.Samourai.Nom;
                
                if (samouraiVM.IdArme != null)
                {
                    samouraiToEdit.Arme = db.Armes.Find(samouraiVM.IdArme);
                }
                else
                {
                    samouraiToEdit.Arme = null;
                }

                //vider l'ancienne liste
                samouraiToEdit.ArtMartials.Clear();

                if (samouraiVM.IdsArtMartial != null)
                {
                    foreach (var item in samouraiVM.IdsArtMartial)
                    {
                        samouraiToEdit.ArtMartials = db.ArtMartials.Where(x => samouraiVM.IdsArtMartial.Contains(x.Id)).ToList();
                    }
                }
                else
                {
                    samouraiToEdit.ArtMartials = null;
                }
                //permet de dire que je suis ds un état de changement c'est facultatif
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
