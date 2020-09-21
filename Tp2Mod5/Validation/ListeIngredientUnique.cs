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
        //ne fonctionne pas pr edit. Il faut exclure le pizza courante donc récup le context
        public override bool IsValid(object listIdIngredients)
        {
            bool result = true;
            List<Pizza> listePizzas = FakeDBPizza.Instance.ListePizza;

            if (listIdIngredients is List<int>)
            {
                var resultId = listIdIngredients as List<int>;

                foreach (var pizza in listePizzas)
                {
                    if (pizza.Ingredients.All(x => resultId.Contains(x.Id)))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        // permet de récup l'id de la pizza pour l'edit
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza comporte déjà les mêmes ingrédients";
        }
    }
}
