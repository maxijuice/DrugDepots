using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Depots.BLL.Interface.DTO;

namespace Depots.WebUI.Models
{
    public class DepotViewModel
    {
        public DepotDTO Depot { get; set; }
        public IEnumerable<DrugUnitDTO> DepotDrugUnits { get; set; }
        public int? CountUnits => DepotDrugUnits?.Count();
    }
}