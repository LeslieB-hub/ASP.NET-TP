﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public class SolarSystem : IDbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Planet> planets;

        public virtual List<Planet> Planets
        {
            get { return planets; }
            set { planets = value; }
        }




    }
}