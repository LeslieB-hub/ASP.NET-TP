using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Rectangle1 : Cote4
    {

        public override string ToString()
        {
            return String.Format("Rectangle de longueur {0} at largeur {1} \nAire = {2} \nPérimètre = {3}\n", this.Longueur, this.Largeur, this.Aire(), this.Perimetre());
        }
    }
}
