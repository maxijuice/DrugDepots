using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.BLL.Interface.DTO;
using Depots.ORM.Entities;

namespace Depots.BLL.Interface.Mapper
{
    public static class ToDTOExtensions
    {
        public static CountryDTO ToDTO(this Country country)
        {
            return new CountryDTO()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                SupplyingDepot = country.SupplyingDepotId == null ? null
                    : new DepotDTO() { DepotId = (int)country.SupplyingDepotId }
            };
        }

        public static DrugTypeDTO ToDTO(this DrugType drugType)
        {
            return new DrugTypeDTO()
            {
                DrugTypeId = drugType.DrugTypeId,
                DrugTypeName = drugType.DrugTypeName,
                DrugTypeWeight = drugType.DrugTypeWeight
            };
        }

        public static DrugUnitDTO ToDTO(this DrugUnit drugUnit)
        {
            return new DrugUnitDTO()
            {
                DrugUnitId = drugUnit.DrugUnitId,
                PickNumber = drugUnit.PickNumber,
                DrugType = drugUnit.DrugTypeId == null ? null
                    : new DrugTypeDTO() { DrugTypeId = (int)drugUnit.DrugTypeId},
                Depot = drugUnit.DepotId == null ? null
                    : new DepotDTO() {  DepotId = (int)drugUnit.DepotId }
            };
        }

        public static DepotDTO ToDTO(this Depot depot)
        {
            return new DepotDTO()
            {
                DepotId = depot.DepotId,
                DepotName = depot.DepotName,
                Country = depot.CountryId == null ? null
                    : new CountryDTO() { CountryId = (int)depot.CountryId },
            };
        }
    }
}
