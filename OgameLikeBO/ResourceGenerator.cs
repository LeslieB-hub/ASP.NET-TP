using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgameLikeBO
{
    public abstract class ResourceGenerator : Building
    {
        public abstract List<Resource> ResourceBySecond();
    }
}
