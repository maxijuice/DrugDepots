using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Depots.BLL.Interface.DTO;

namespace Depots.WebUI.Models
{
    public class OrderSummaryViewModel
    {
        public DepotDTO Depot { get; set; }
        public IEnumerable<DrugUnitDTO> UnitsToSend { get; set; }

        public string DepotSummary => $"#{Depot.DepotId}, {Depot.DepotName}, {Depot.Country.CountryName}";

        public string UnitSummary(DrugUnitDTO unit)
        {
            return $"#{unit.DrugUnitId}, {unit.DrugType.DrugTypeName}, Pick num. {unit.PickNumber}";
        }
    }
}