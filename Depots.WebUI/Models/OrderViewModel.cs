using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Depots.WebUI.Models
{
    public class OrderViewModel
    {
        public int DepotId { get; set; }
        public IList<OrderLine> Lines { get; set; } 
    }

    public class OrderLine
    {
        public int DrugTypeId { get; set; }
        public int Amount { get; set; }
    }
}