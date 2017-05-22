using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Depots.BLL.Interface.DTO;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

namespace Depots.WebUI.Models
{
    public class DepotViewModel
    {
        public const double UnitsRatio = 1 / 2.2;
        public DepotDTO Depot { get; set; }
        public IEnumerable<DrugUnitDTO> DepotDrugUnits { get; set; }
        public int? CountUnits => DepotDrugUnits?.Count();

        public IEnumerable<DrugTypeDTO> DepotDrugTypes => DepotDrugUnits?.Select(unit => unit.DrugType);

        public IEnumerable<DrugTypeDTO> DistinctDepotDrugTypes => DepotDrugUnits?.Select(unit => unit.DrugType).DistinctBy(type => type.DrugTypeId);

        public double Capacity => Math.Round(DepotDrugUnits.Sum(unit => ((unit.DrugType.DrugTypeWeight ?? default(double)) * UnitsRatio)), 2);

        public double DrugTypeWeight(DrugTypeDTO type)
        {
            return Math.Round((type.DrugTypeWeight ?? default(double)) * UnitsRatio, 2);
        }

        public string Summary => Depot.DepotName + ", " + Depot.Country.CountryName + " (" + CountUnits + " units)";

    }
}