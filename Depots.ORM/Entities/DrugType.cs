using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depots.ORM.Entities
{
    [Table("DrugType")]
    public partial class DrugType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugType()
        {
            DrugUnits = new HashSet<DrugUnit>();
        }

        public int DrugTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugTypeName { get; set; }

        public float? DrugTypeWeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugUnit> DrugUnits { get; set; }
    }
}
