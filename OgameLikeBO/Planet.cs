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
        
        [MinLength(5)]
        [MaxLength(20)]
        private string name;
        [Range(0, 99999999)]
        private int? caseNb;
        private Resource energy;
        private Resource oxygen;
        private Resource steel;
        private Resource uranium;

        [NotMapped]
        private List<Building> buildings;




        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int? CaseNb
        {
            get { return caseNb; }
            set { caseNb = value; }
        }


        public virtual Resource Energy
        {
            get { return energy; }
            set { energy = value; }
        }


        public virtual Resource Oxygen
        {
            get { return oxygen; }
            set { oxygen = value; }
        }


        public virtual Resource Steel
        {
            get { return steel; }
            set { steel = value; }
        }

        

        public virtual Resource Uranium
        {
            get { return uranium; }
            set { uranium = value; }
        }



        [NotMapped]
        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

    }
}
