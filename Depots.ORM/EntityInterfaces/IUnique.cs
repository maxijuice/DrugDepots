using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depots.ORM.EntityInterfaces
{
    public interface IUnique
    {
        dynamic EntityID { get; }
    }
}
