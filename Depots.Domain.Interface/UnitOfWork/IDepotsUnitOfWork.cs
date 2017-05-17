using Depots.DAL.Interface.Repositories;
using Depots.ORM;
using Depots.ORM.Entities;

namespace Depots.DAL.Interface.UnitOfWork
{
    public interface IDepotsUnitOfWork : IUnitOfWork
    {
        ICountryRepository Countries { get; }
        IDepotRepository Depots { get; }  
        IDrugTypeRepository DrugTypes { get; }
        IDrugUnitRepository DrugUnits { get; }  
    }
}
