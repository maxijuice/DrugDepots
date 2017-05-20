using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Depots.WebUI.Models
{
    public class OrderViewModel
    {
        public int DepotId { get; set; }
        IList<OrderLine> Lines { get; set; } 
    }

    public class OrderLine
    {
        public int DrugTypeId { get; set; }
        public int Amount { get; set; }
    }
}