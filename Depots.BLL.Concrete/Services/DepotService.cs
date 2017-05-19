using System;
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

        public IEnumerable<DepotDTO> GetPage(int pageNumber, int pageSize)
        {
            IEnumerable<DepotDTO> depotsPerPage = depots.GetAll().OrderBy(depot => depot.DepotId).ThenBy(depot => depot.CountryId)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                .Select(depot => depot.ToDTO()).ToList();

            foreach (var depot in depotsPerPage)
            {
               AddCountryToDepot(depot);
            }

            return depotsPerPage;
        }

        public int Count => depots.GetAll().Count();

        DepotDTO IService<DepotDTO>.GetById(dynamic id)
        {
            if (id.GetType() != typeof(Int32))
                throw new ArgumentException(nameof(id));

            return GetById(id);
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
