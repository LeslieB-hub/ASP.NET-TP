using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Rectangle : Forme
    {
        private int largeur;
        private int longueur;

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }

        public int Largeur { get => largeur; set => largeur = value; }

        public override double Aire()
        {
            return this.longueur * this.largeur;
        }

        public override double Perimetre()
        {
            return (this.longueur * 2) + (this.Largeur * 2);
        }

        public override string ToString()
        {
            return String.Format("Rectangle de longueur {0} at largeur {1} \nAire = {2} \nPérimètre = {3}\n", this.Longueur, this.Largeur,this.Aire(), this.Perimetre());
        }
    }
}
