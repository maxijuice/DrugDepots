using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.DAL.Interface.Repository;
using Depots.ORM.Entities;

namespace Depots.DAL.Concrete.Repositories
{
    public class DrugUnitRepository : CommonRepository<DrugUnit>, IDrugUnitRepository
    { 
        public DrugUnitRepository(DbContext context) : base(context) { }
    }
}
