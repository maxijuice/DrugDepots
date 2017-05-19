using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Depots.WebUI.Models
{
    public class DepotsListViewModel
    {
        public IEnumerable<DepotViewModel> Depots { get; set; } 
        public PagingInfo PagingInfo { get; set; }
    }
}