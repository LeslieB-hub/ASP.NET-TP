using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1Mod2.Entities
{
    public class Triangle : Forme
    {
        private int a;
        private int b;
        private int c;

        public int A { get => a; set => a = value; }
        public int B { get => b; set => b = value; }
        public int C { get => c; set => c = value; }

        public override double Aire()
        {
            return 0;
        }

        public override double Perimetre()
        {
            double perimetre;
            perimetre = this.A + this.B + this.C;
            return perimetre;
        }

        public override string ToString()
        {
            return String.Format("Triangle de côté A={0}, B={1}, C={2} \nAire = {3} \nPérimètre = {4}\n", this.A, this.B, this.C, this.Aire(), this.Perimetre());
        }
    }
}
