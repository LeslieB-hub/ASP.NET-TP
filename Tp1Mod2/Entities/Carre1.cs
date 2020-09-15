using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Carre1 : Cote4
    {
        private int largeur;

        public virtual int Largeur
        {
            get { return largeur = base.Longueur; }
            set { largeur = value; }
        }

    }
}
