using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depots.BLL.Concrete.DTO
{
    public class DrugTypeDTO
    {
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public float? DrugTypeWeight { get; set; }
    }
}
