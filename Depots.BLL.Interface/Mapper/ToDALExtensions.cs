using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Depots.BLL.Interface.DTO;
using Depots.ORM.Entities;

namespace Depots.BLL.Interface.Mapper
{
    public static class ToDALExtensions
    {
        public static Country ToDAL(this CountryDTO countryDTO)
        {
            return new Country()
            {
                CountryId = countryDTO.CountryId,
                CountryName = countryDTO.CountryName,
                SupplyingDepotId = countryDTO.SupplyingDepot?.DepotId
            };
        }

        public static Depot ToDAL(this DepotDTO depotDTO)
        {
            return new Depot()
            {
                DepotId = depotDTO.DepotId,
                DepotName = depotDTO.DepotName,
                CountryId = depotDTO.Country?.CountryId
            };
        }

        public static DrugUnit ToDAL(this DrugUnitDTO drugUnitDTO)
        {
            return new DrugUnit()
            {
                DrugUnitId = drugUnitDTO.DrugUnitId,
                DrugTypeId = drugUnitDTO.DrugType?.DrugTypeId,
                DepotId = drugUnitDTO.Depot?.DepotId,
                PickNumber = drugUnitDTO.PickNumber
            };
        }

        public static DrugTypeDTO ToDAL(this DrugTypeDTO drugTypeDTO)
        {
            return new DrugTypeDTO()
            {
                DrugTypeId = drugTypeDTO.DrugTypeId,
                DrugTypeName = drugTypeDTO.DrugTypeName,
                DrugTypeWeight = drugTypeDTO.DrugTypeWeight
            };
        }
    }
}
