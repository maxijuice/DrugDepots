using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Depots.BLL.Interface.DTO;
using Depots.ORM.Entities;

namespace Depots.WebUI.Models
{
    public class DrugUnitsListViewModel
    {
        public IEnumerable<DrugUnitDTO> DrugUnits { get; set; } 
        public IEnumerable<DepotDTO> ExistingDepots { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}