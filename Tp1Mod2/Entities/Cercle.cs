using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Cercle : Forme
    {
        private int rayon;

        public int Rayon
        {
            get { return rayon; }
            set { rayon = value; }
        }

        public override double Aire()
        {
            return Math.Pow(rayon, 2) * Math.PI;
        }

        public override double Perimetre()
        {
            return rayon * 2 * Math.PI;
        }

        public override string ToString()
        {
            return String.Format("Cercle de rayon {0} \nAire = {1} \nPérimètre = {2}\n", this.Rayon, this.Aire(), this.Perimetre());
        }
    }
}
