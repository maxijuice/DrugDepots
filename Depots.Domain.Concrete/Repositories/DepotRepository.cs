using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.DAL.Interface.Repositories;
using Depots.ORM.Entities;

namespace Depots.DAL.Concrete.Repositories
{
    public class DepotRepository : CommonRepository<Depot>, IDepotRepository
    {
        public DepotRepository(DbContext context) : base(context) { }
    }
}
