using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1Mod3.BO;

namespace Tp1Mod3
{
 

    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {
            InitialiserDatas();

            //Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            Console.WriteLine("Afficher la liste des prénoms des auteurs dont le nom commence par G");
            foreach (var item in ListeAuteurs.Where(n => n.Nom.StartsWith("G")))
            {
                Console.WriteLine(item.Prenom);
            }

            //Afficher l’auteur ayant écrit le plus de livres
            Console.WriteLine("Afficher l’auteur ayant écrit le plus de livres");
            foreach (IGrouping<Auteur, Livre> item in ListeLivres.GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Key.Nom + " " + item.Count()+ " ");
            }




            //Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine("Afficher le nombre moyen de pages par livre par auteur\n");
            foreach (IGrouping<Auteur, Livre> item in ListeLivres.GroupBy(x => x.Auteur))
            {
                
                Console.WriteLine(item.Key.Nom + " " + item.Average(x => x.NbPages));

                
            }

            //Afficher le titre du livre avec le plus de pages
            Console.WriteLine("Afficher le titre du livre avec le plus de pages");
            Console.WriteLine(ListeLivres.OrderBy(x => x.NbPages).First().Titre);

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            Console.WriteLine("Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)");
            //var moy = ListeAuteurs.Average(x => x.Factures);


            //Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("Afficher les auteurs et la liste de leurs livres");
            foreach (IGrouping<Auteur, Livre> item in ListeLivres.GroupBy(a => a.Auteur))
            {
                foreach (var subitem in item)
                {
                    Console.WriteLine(item.Key.Nom + ": " + subitem.Titre);
                }
                
            }


            //Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine("Afficher les titres de tous les livres triés par ordre alphabétique");
            foreach (var item in ListeLivres.OrderBy(x => x.Titre))
            {
                Console.WriteLine(item.Titre);
            }

            //Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            Console.WriteLine("Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne");
            var moy = ListeLivres.Average(x => x.NbPages);
            Console.WriteLine(moy);
            foreach (var item in ListeLivres.Where(x => x.NbPages > moy))
            {
                Console.WriteLine(item.Titre);
            }

            //Afficher l'auteur ayant écrit le moins de livres
            



            Console.ReadKey();
        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
