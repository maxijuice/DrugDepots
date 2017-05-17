using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depots.BLL.Concrete.DTO
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int? SupplyingDepotId { get; set; }
    }
}
