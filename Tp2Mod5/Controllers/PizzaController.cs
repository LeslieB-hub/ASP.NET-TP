using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp2Mod5.Data;
using Tp2Mod5.Models;

namespace Tp2Mod5.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            List<BO.Pizza> ListePizzas = FakeDBPizza.Instance.ListePizza;
            return View(ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel pizzaVM = new PizzaViewModel();
            pizzaVM.ListePates = FakeDBPizza.Instance.ListePates;
            pizzaVM.ListeIngredients = FakeDBPizza.Instance.ListeIngredients;
            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pVM)
        {
            try
            {
                // TODO: Add insert logic here
                //vm.Chat.Couleur = FakeDbCat.Instance.Couleurs.FirstOrDefault(x => x.Id == vm.IdCouleur);
                //FakeDbCat.Instance.Chats.Add(vm.Chat);
                pVM.pizza.Pate = FakeDBPizza.Instance.ListePates.FirstOrDefault(x => x.Id == pVM.IdPate);
                foreach (var item in pVM.IdIngredients)
                {
                    BO.Ingredient ingredient = FakeDBPizza.Instance.ListeIngredients.FirstOrDefault(x => x.Id == item);
                    pVM.pizza.Ingredients.Add(ingredient);
                }
                Console.WriteLine(pVM.pizza);
                FakeDBPizza.Instance.ListePizza.Add(pVM.pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                pVM.ListePates = FakeDBPizza.Instance.ListePates;
                pVM.ListeIngredients = FakeDBPizza.Instance.ListeIngredients;
                return View(pVM);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel pizzaVM = new PizzaViewModel();
            pizzaVM.pizza = FakeDBPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
            pizzaVM.ListePates = FakeDBPizza.Instance.ListePates;
            pizzaVM.ListeIngredients = FakeDBPizza.Instance.ListeIngredients;
            return View(pizzaVM);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
