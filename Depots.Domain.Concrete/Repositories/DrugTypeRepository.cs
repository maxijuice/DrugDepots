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
    public class DrugTypeRepository : CommonRepository<DrugType>, IDrugTypeRepository
    {
        public DrugTypeRepository(DbContext context) : base(context) { }
    }
}
