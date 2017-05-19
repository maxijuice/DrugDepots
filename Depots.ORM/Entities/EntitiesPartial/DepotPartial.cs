using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.ORM.EntityInterfaces;

namespace Depots.ORM.Entities
{
    public partial class Depot : IUnique
    {
        public dynamic EntityID => DepotId;
    }
}
