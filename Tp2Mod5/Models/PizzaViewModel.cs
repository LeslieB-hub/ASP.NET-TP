using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp2Mod5.Models
{
    public class PizzaViewModel
    {
        public BO.Pizza pizza { get; set; }
        public List<BO.Pate> ListePates { get; set; }

        public int IdPate { get; set; }

        public List<BO.Ingredient> ListeIngredients { get; set; }

        public List<int> IdIngredients { get; set; }
    }
}