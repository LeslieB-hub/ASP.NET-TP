using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ResourcesValidation : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Il ne doit pas être possible d’assigner plus de 4 « Resource » à une « Planet »";
        }

        public override bool IsValid(object resources)
        {
            int maxValue = 4;
            bool lessThan4Values = false;
            bool resourcesName = false;
            bool result = false;
            if (resources is List<Resource>)
            {
                var listResources = resources as List<Resource>;
                if (listResources.Count <= maxValue)
                {
                    lessThan4Values = true;
                }

                foreach (var resource in listResources)
                {
                    if (resource.Name.Equals(NomsResources.énergie) && resource.Name.Equals(NomsResources.acier)
                        && resource.Name.Equals(NomsResources.oxygène) && resource.Name.Equals(NomsResources.uranium))
                    {
                        resourcesName = true;
                    }
                }

                if (resourcesName && lessThan4Values)
                {
                    result = true;
                }

            }
            return result;
        }
    }
}
