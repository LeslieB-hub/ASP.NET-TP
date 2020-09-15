using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public abstract class Forme
    {
        public abstract double Aire();

        public abstract double Perimetre();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
