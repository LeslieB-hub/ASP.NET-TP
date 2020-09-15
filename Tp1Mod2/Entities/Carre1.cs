using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Carre1 : Cote4
    {
       // private int largeur;

        public virtual int Largeur
        {
            get { return base.Largeur = base.Longueur; }
            set { base.Largeur = value; }
        }
        public override string ToString()
        {
            return String.Format("Carré1 de côté {0} \nAire = {1} \nPérimètre = {2}\n", this.Longueur, this.Aire(), this.Perimetre());
        }
    }
}
