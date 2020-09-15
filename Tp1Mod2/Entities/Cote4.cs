using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public abstract class Cote4 : Forme
    {
        
        private int longueur;

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }


        public override double Aire()
        {
            return this.longueur * this.longueur;
        }

        public override double Perimetre()
        {
            return (this.longueur * 2) + (this.longueur * 2);
        }


    }
}
