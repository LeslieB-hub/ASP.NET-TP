using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Carre : Forme
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
            return this.longueur * 4;
        }
        public override string ToString()
        {
            return String.Format("Carré de côté {0} \nAire = {1} \nPérimètre = {2}\n", this.Longueur, this.Aire(), this.Perimetre());
        }
    }
}
