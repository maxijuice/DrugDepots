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
        public DepotDTO Depot { get; set; }
        public IEnumerable<DrugUnitDTO> DepotDrugUnits { get; set; }
        public int? CountUnits => DepotDrugUnits?.Count();

        public IEnumerable<DrugTypeDTO> DepotDrugTypes =>
            DepotDrugUnits?.Select(unit => unit.DrugType);

        public string Summary => Depot.DepotName + ", " + Depot.Country.CountryName + " (" + CountUnits + " units)";

    }
}