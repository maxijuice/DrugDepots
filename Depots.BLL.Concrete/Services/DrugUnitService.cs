using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.BLL.Interface.DTO;
using Depots.BLL.Interface.Mapper;
using Depots.BLL.Interface.Services;
using Depots.DAL.Interface.Repositories;
using Depots.DAL.Interface.UnitOfWork;
using Depots.ORM.Entities;

namespace Depots.BLL.Concrete.Services
{
    public class DrugUnitService : IDrugUnitService
    {
        private IDepotsUnitOfWork unitOfWork;
        private IDrugUnitRepository drugUnits;

        public DrugUnitService(IDepotsUnitOfWork uow)
        {
            unitOfWork = uow;
            drugUnits = uow.DrugUnits;
        }

        public IEnumerable<DrugUnitDTO> GetAll()
        {
            IEnumerable<DrugUnitDTO> allDrugUnits = drugUnits.GetAll().ToList().Select(drug => drug.ToDTO()).ToList();
            foreach (var drug in allDrugUnits)
            {
                AddDepotToUnit(drug);
                AddDrugTypeToUnit(drug);
            }

            return allDrugUnits;
        }

        public DrugUnitDTO GetById(string id)
        {
            var drug = drugUnits.GetById(id).ToDTO();
            AddDepotToUnit(drug);
            AddDrugTypeToUnit(drug);

            return drug;
        }

        public IEnumerable<DrugUnitDTO> GetByDepot(int? depotId)
        {
            DepotDTO depot = unitOfWork.Depots.GetById(depotId).ToDTO();
            IEnumerable<DrugUnitDTO> unitsOfDepot = drugUnits.GetAll().Where(unit => unit.DepotId == depotId).ToList()
                .Select(unit => unit.ToDTO()).ToList();
            
            foreach (var unit in unitsOfDepot)
            {
                AddDrugTypeToUnit(unit);
                unit.Depot = depot;
            }

            return unitsOfDepot;
        }

        public void UpdateUnit(DrugUnitDTO unitToUpdate)
        {
            drugUnits.Update(unitToUpdate.ToDAL());
            unitOfWork.Commit();
        }

        public int Count => drugUnits.GetAll().Count();

        public IEnumerable<DrugUnitDTO> GetPage(int pageNumber, int pageSize)
        {
            IEnumerable<DrugUnitDTO> unitsPerPage =  drugUnits.GetAll().OrderBy(du => du.DrugTypeId).ThenBy(du => du.PickNumber)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
                .Select(du => du.ToDTO()).ToList();

            foreach (var drug in unitsPerPage)
            {
                AddDepotToUnit(drug);
                AddDrugTypeToUnit(drug);
            }

            return unitsPerPage;
        }

        DrugUnitDTO IService<DrugUnitDTO>.GetById(dynamic id)
        {
            return GetById(id.ToString());
        }

        private void AddDrugTypeToUnit(DrugUnitDTO unit)
        {
            if (unit.DrugType != null)
            {
                DrugTypeDTO typeDTO = unitOfWork.DrugTypes.GetById(unit.DrugType.DrugTypeId).ToDTO();
                unit.DrugType = typeDTO;
            }
        }

        private void AddDepotToUnit(DrugUnitDTO unit)
        {
            if (unit.Depot != null)
            {
                DepotDTO depotDTO = unitOfWork.Depots.GetById(unit.Depot.DepotId).ToDTO();
                unit.Depot = depotDTO;
            }
        }
    }
}
