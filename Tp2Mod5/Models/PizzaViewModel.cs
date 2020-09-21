using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tp2Mod5.Validation;

namespace Tp2Mod5.Models
{
    public class PizzaViewModel
    {
        
        public BO.Pizza pizza { get; set; }
        public List<BO.Pate> ListePates { get; set; } = new List<BO.Pate>();

        [Required]
        public int? IdPate { get; set; }

        public List<BO.Ingredient> ListeIngredients { get; set; } = new List<BO.Ingredient>();

        [Required]
        [ValidationIngredient]
        [ListeIngredientUnique]
        public List<int> IdIngredients { get; set; } = new List<int>();
    }
}