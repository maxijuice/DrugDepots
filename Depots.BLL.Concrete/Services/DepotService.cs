using System.Collections.Generic;
using System.Linq;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Mapper;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.DAL.Interface.UnitOfWork;
using Depots.ORM.Entities;

namespace Depots.BLL.Concrete.Services
{
    public class DepotService : IDepotService
    {
        private IDepotRepository depots;
        private IDepotsUnitOfWork unitOfWork;
        public DepotService(IDepotsUnitOfWork uow)
        {
            unitOfWork = uow;
            depots = uow.Depots;
        }

        public IEnumerable<DepotDTO> GetAll()
        {
            IEnumerable<DepotDTO> allDepots = depots.GetAll().ToList().Select(depot => depot.ToDTO()).ToList();
            foreach (var depot in allDepots)
            {
                AddCountryToDepot(depot);
            }
                
            return allDepots;
        }

        public DepotDTO GetById(int id)
        {
            var depot = depots.GetById(id).ToDTO();
            AddCountryToDepot(depot);

            return depot;
        }

        public IEnumerable<DepotDTO> GetByCountry(int? countryId)
        {
            IEnumerable<DepotDTO> depotsOfCountry = depots.GetAll().Where(depot => depot.CountryId == countryId).ToList()
                       .Select(depot => depot.ToDTO()).ToList();

            foreach (var depot in depotsOfCountry)
            {
                AddCountryToDepot(depot);
            }

            return depotsOfCountry;
        }

        private void AddCountryToDepot(DepotDTO depotToFill)
        {
            if (depotToFill.Country != null)
            {
                CountryDTO country = unitOfWork.Countries.GetById(depotToFill.Country.CountryId).ToDTO();
                country.SupplyingDepot = depotToFill;
                depotToFill.Country = country;
            }
        }
    }
}
