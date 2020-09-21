using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BO.Data;

namespace Tp2Mod5.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class ListeIngredientUnique : ValidationAttribute
    {
        public override bool IsValid(object listIdIngredients)
        {
            bool result = true;
            List<Pizza> listePizzas = FakeDBPizza.Instance.ListePizza;
            var resultId = listIdIngredients as List<int>;

            foreach (var pizza in listePizzas)
            {
                if (pizza.Ingredients.All(x => resultId.Contains(x.Id)))
                {
                    result = false;
                    break;
                }               
            }



            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza comporte déjà les mêmes ingrédients";
        }
    }
}
