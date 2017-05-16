using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Depots.ORM.Entities;

namespace Depots.WebUI.Models
{
    public class DrugUnitsListViewModel
    {
        public IEnumerable<DrugUnit> DrugUnits { get; set; } 
        public IEnumerable<Depot> ExistingDepots { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}