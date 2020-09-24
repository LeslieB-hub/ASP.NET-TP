using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public class Resource : IDbEntity
    {
        private long id;
        public long Id { get => id; set => id = value; }

        private string name;

        private int? lasMyProperty;
        private DateTime lastUpdate;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        public int? LasMyProperty
        {
            get { return lasMyProperty; }
            set { lasMyProperty = value; }
        }


        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

    }
}
