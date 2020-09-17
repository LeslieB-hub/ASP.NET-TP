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
                pVM.pizza.Pate = FakeDBPizza.Instance.ListePates.FirstOrDefault(x => x.Id == pVM.IdPate);
                foreach (var item in pVM.IdIngredients)
                {
                    BO.Ingredient ingredient = FakeDBPizza.Instance.ListeIngredients.FirstOrDefault(x => x.Id == item);
                    pVM.pizza.Ingredients.Add(ingredient);
                }
                Console.WriteLine(pVM.pizza);

                //setter l'Id
                pVM.pizza.Id = FakeDBPizza.Instance.ListePizza.Count == 0 ? 1 : FakeDBPizza.Instance.ListePizza.Max(x => x.Id) + 1;

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

            if (pizzaVM.pizza.Pate != null)
            {
                pizzaVM.IdPate = pizzaVM.pizza.Pate.Id;
            }
            
            if (pizzaVM.pizza.Ingredients.Any())
            {
                pizzaVM.IdIngredients = pizzaVM.pizza.Ingredients.Select(x => x.Id).ToList(); //select tt les id des ingredients               
            }

            pizzaVM.ListePates = FakeDBPizza.Instance.ListePates;
            pizzaVM.ListeIngredients = FakeDBPizza.Instance.ListeIngredients;
            return View(pizzaVM);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pVM)
        {
            try
            {
                // TODO: Add update logic here
                BO.Pizza pizza = FakeDBPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == pVM.pizza.Id);
                pizza.Nom = pVM.pizza.Nom;
                pizza.Pate = FakeDBPizza.Instance.ListePates.FirstOrDefault(x => x.Id == pVM.IdPate);
                pizza.Ingredients = FakeDBPizza.Instance.ListeIngredients.Where(x => pVM.IdIngredients.Contains(x.Id)).ToList();
                
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
            PizzaViewModel pizzaVM = new PizzaViewModel();
            pizzaVM.pizza = FakeDBPizza.Instance.ListePizza.FirstOrDefault(x => x.Id == id);
            return View(pizzaVM);
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
