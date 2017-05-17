using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depots.BLL.Concrete.DTO
{
    public class DrugUnitDTO
    {
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }
        public int? DrugTypeId { get; set; }
        public int? DepotId { get; set; }

    }
}
