using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depots.ORM.Entities
{
    [Table("DrugUnit")]
    public partial class DrugUnit
    {
        [StringLength(20)]
        public string DrugUnitId { get; set; }

        public int PickNumber { get; set; }

        public int? DrugTypeId { get; set; }

        public int? DepotId { get; set; }

        public virtual Depot Depot { get; set; }

        public virtual DrugType DrugType { get; set; }
    }
}
