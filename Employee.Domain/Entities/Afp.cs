using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities
{
    public class Afp
    {
        [Key]
        public int AfpId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountPercentage { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
