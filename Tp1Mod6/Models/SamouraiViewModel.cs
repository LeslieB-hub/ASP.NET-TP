using BOMod6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp1Mod6.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }

        public int? IdArme { get; set; }
    }
}