using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.UnitOfWork;

namespace Depots.BLL.Concrete.Services
{
    public class DepotService : IDepotService
    {
        private IDepotsUnitOfWork unitOfWork;
        public DepotService(IDepotsUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public IEnumerable<DepotDTO> GetAllDepots()
        {
            return unitOfWork.Depots.GetAll().ProjectTo<DepotDTO>().AsEnumerable();
        }
    }
}
