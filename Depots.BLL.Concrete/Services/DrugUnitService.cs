using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.UnitOfWork;

namespace Depots.BLL.Concrete.Services
{
    public class DrugUnitService : IDrugUnitService
    {
        private IDepotsUnitOfWork unitOfWork;
        public DrugUnitService(IDepotsUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public IEnumerable<DrugUnitDTO> GetAllDrugUnits()
        {
            return unitOfWork.DrugUnits.GetAll().ProjectTo<DrugUnitDTO>().AsEnumerable();
        }

        public int CountUnits => unitOfWork.DrugUnits.GetAll().Count();

        public IEnumerable<DrugUnitDTO> GetPage(int pageNumber, int pageSize)
        {
            return unitOfWork.DrugUnits.GetAll().Skip((pageNumber - 1)*pageSize).Take(pageSize).ProjectTo<DrugUnitDTO>().AsEnumerable();
        }
    }
}
