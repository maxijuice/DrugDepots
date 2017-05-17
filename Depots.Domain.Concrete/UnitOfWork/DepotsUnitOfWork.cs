using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.DAL.Concrete.Repositories;
using Depots.DAL.Interface.Repositories;
using Depots.DAL.Interface.UnitOfWork;
using Depots.ORM.Entities;

namespace Depots.DAL.Concrete.UnitOfWork
{
    public class DepotsUnitOfWork : IDepotsUnitOfWork
    {
        private readonly DbContext context;
        private ICountryRepository countries;
        private IDrugUnitRepository drugUnits;
        private IDrugTypeRepository drugTypes;
        private IDepotRepository depots;
        public DepotsUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public ICountryRepository Countries => countries ?? (countries = new CountryRepository(context));

        public IDepotRepository Depots => depots ?? (depots = new DepotRepository(context));

        public IDrugTypeRepository DrugTypes => drugTypes ?? (drugTypes = new DrugTypeRepository(context));

        public IDrugUnitRepository DrugUnits => drugUnits ?? (drugUnits = new DrugUnitRepository(context));

        public void Commit()
        { 
            context?.SaveChanges();
        }
    }
}
