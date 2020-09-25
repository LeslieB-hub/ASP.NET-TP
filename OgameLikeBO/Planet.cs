using OgameLikeBO.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public class Planet : IDbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }
        

        private string name;
        
        private int? caseNb;


        private List<Resource> resources;

        [NotMapped]
        private List<Building> buildings;

        [MinLength(5), MaxLength(20)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Range(0, int.MaxValue)]
        public int? CaseNb
        {
            get { return caseNb; }
            set { caseNb = value; }
        }

        [ResourcesValidation]
        public List<Resource> Resources
        {
            get { return resources; }
            set { resources = value; }
        }



        [NotMapped]
        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

    }
}
