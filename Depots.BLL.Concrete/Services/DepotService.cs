using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.DAL.Interface.UnitOfWork;
using Depots.ORM.Entities;

namespace Depots.BLL.Concrete.Services
{
    public class DepotService : CommonService, IDepotService
    {
        private IDepotRepository depots;

        public DepotService(IDepotsUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
            depots = uow.Depots;
        }

        public IEnumerable<DepotDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Depot>, IEnumerable<DepotDTO>>(depots.GetAll());
        }

        public DepotDTO GetById(string id)
        {
            return mapper.Map<Depot, DepotDTO>(depots.GetById(id));
        }

        public IEnumerable<DepotDTO> GetByCountry(int? countryId)
        {
            return mapper.Map<IEnumerable<Depot>, IEnumerable<DepotDTO>>(depots.GetAll().Where(d => d.CountryId == countryId));
        }
    }
}
