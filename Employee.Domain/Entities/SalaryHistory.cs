using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain
{
    public class SalaryHistory
    {
        [Key]
        public int SalaryHistoryId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PreviousSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NewSalary { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(255)]
        public string Reason { get; set; }

        public string ModifiedByUser
        {
            get; set;
        }
    }
}
