﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1Mod2.Entities;

namespace Tp1Mod2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var formes = new List<Forme>();
            formes.Add(new Cercle { Rayon = 3 });
            formes.Add(new Rectangle { Largeur = 3, Longueur = 4 });
            formes.Add(new Carre { Longueur = 3 });
            formes.Add(new Triangle { A = 4, B = 5, C = 6 });
            //Essai2
            formes.Add(new Carre1 { Longueur = 3 });
            formes.Add(new Rectangle1 { Longueur = 4, Largeur = 4});

            foreach (var forme in formes)
            {
                Console.WriteLine(forme);
            }

            

            Console.ReadKey();
        }
    }
}