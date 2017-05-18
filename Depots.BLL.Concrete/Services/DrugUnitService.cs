using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.DAL.Interface.UnitOfWork;
using Depots.ORM.Entities;

namespace Depots.BLL.Concrete.Services
{
    public class DrugUnitService : CommonService, IDrugUnitService
    {
        private IDrugUnitRepository drugUnits;

        public DrugUnitService(IDepotsUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
            drugUnits = uow.DrugUnits;
        }

        public IEnumerable<DrugUnitDTO> GetByDepot(int? depotId)
        {
            return mapper.Map<IEnumerable<DrugUnit>, IEnumerable<DrugUnitDTO>>(drugUnits.GetAll().Where(du => du.DepotId == depotId));
        }

        public void UpdateUnit(DrugUnitDTO unitToUpdate)
        {
            drugUnits.Update(mapper.Map<DrugUnitDTO, DrugUnit>(unitToUpdate));
            unitOfWork.Commit();
        }

        public int CountUnits => unitOfWork.DrugUnits.GetAll().Count();

        public IEnumerable<DrugUnitDTO> GetPage(int pageNumber, int pageSize)
        {
            return
                mapper.Map<IEnumerable<DrugUnit>, IEnumerable<DrugUnitDTO>>(
                    drugUnits.GetAll().OrderBy(du => du.DrugTypeId).ThenBy(du => du.PickNumber).Skip((pageNumber - 1)*pageSize).Take(pageSize));
        }

        public IEnumerable<DrugUnitDTO> GetAll()
        {
            return mapper.Map<IEnumerable<DrugUnit>, IEnumerable<DrugUnitDTO>>(drugUnits.GetAll());
        }

        public DrugUnitDTO GetById(string id)
        {
            return mapper.Map<DrugUnit, DrugUnitDTO>(drugUnits.GetById(id));
        }
    }
}
