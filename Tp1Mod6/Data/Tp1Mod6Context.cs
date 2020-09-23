using BOMod6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tp1Mod6.Data
{
    public class Tp1Mod6Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Tp1Mod6Context() : base("name=Tp1Mod6Context")
        {
        }

        public System.Data.Entity.DbSet<BOMod6.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BOMod6.Arme> Armes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
            //One to one zero monodirectionnel un samourai peut ne pas avoir d'arme et vise versa.
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme).WithOptionalPrincipal();

            //Un art martial peut être associé à zéro ou plusieurs samouraïs. ManyToMany
            // modelBuilder.Entity<Formateur>().HasMany(f => f.Salles).WithMany();
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtMartials).WithMany();

        }

        public System.Data.Entity.DbSet<BOMod6.ArtMartial> ArtMartials { get; set; }
    }
}
