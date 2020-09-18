using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tp2Mod5;

namespace Tp2Mod5.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationIngredient : ValidationAttribute
    {
        public override bool IsValid(object listIdIngredients)
        {
            
            bool result = false;
            if (listIdIngredients is List<int>)
            {
                var resultId = listIdIngredients as List<int>;
                if (resultId.Count >= 2 && resultId.Count <= 5)
                {
                    result = true;
                }
                
            }
            else
            {
                result = false;
            }

            return result;
        }
       public override string FormatErrorMessage(string name)
        {
            return "Une pizza doit avoir entre 2 et 5 ingrédients";
        }

       
    }
}