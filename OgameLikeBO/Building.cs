using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public abstract class Building : IDbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }

        [MinLength(5)]
        [MaxLength(20)]
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Range(0, 99999999)]
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
