using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp2Mod5.Data
{
    public class FakeDBPizza
    {
        private static readonly Lazy<FakeDBPizza> lazy = new Lazy<FakeDBPizza>(() => new FakeDBPizza());

        public static FakeDBPizza Instance
        {
            get { return lazy.Value; }
            //set { myVar = value; }
        }

        public List<BO.Ingredient> ListeIngredients { get; private set; }

        public List<BO.Pate> ListePates { get; private set; }

        public List<BO.Pizza> ListePizza { get; set; }

        private FakeDBPizza()
        {
            this.ListeIngredients = new List<BO.Ingredient>();
            this.ListePates = new List<BO.Pate>();
            this.ListePizza = new List<BO.Pizza>();
            this.InitialiserDatas();

        }

        private void InitialiserDatas()
        {
            ListeIngredients.Add(new BO.Ingredient { Id = 1, Nom = "Mozzarella" });
            ListeIngredients.Add(new BO.Ingredient { Id = 2, Nom = "Jambon" });
            ListeIngredients.Add(new BO.Ingredient { Id = 3, Nom = "Tomate" });
            ListeIngredients.Add(new BO.Ingredient { Id = 4, Nom = "Oignon" });
            ListeIngredients.Add(new BO.Ingredient { Id = 5, Nom = "Cheddar" });
            ListeIngredients.Add(new BO.Ingredient { Id = 6, Nom = "Saumon" });
            ListeIngredients.Add(new BO.Ingredient { Id = 7, Nom = "Champignon" });
            ListeIngredients.Add(new BO.Ingredient { Id = 8, Nom = "Poulet" });

            ListePates.Add(new BO.Pate { Id = 1, Nom = "Pate fine, base crême" });
            ListePates.Add(new BO.Pate { Id = 2, Nom = "Pate fine, base tomate" });
            ListePates.Add(new BO.Pate { Id = 3, Nom = "Pate épaisse, base crême" });
            ListePates.Add(new BO.Pate { Id = 4, Nom = "Pate épaisse, base tomate" });
         
        }
    }
}