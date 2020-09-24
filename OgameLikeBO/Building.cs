using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public abstract class Building : IDbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int? level;

        public int? Level
        {
            get { return level; }
            set { level = value; }
        }

        public abstract int? CellNb();

        public abstract List<Resource> TotalCost();

        public abstract List<Resource> NextCost();

    }
}
