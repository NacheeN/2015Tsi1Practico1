using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class PartTimeEmployee : Employee
    {
        [Required]
        [StringLength(255)]
        [Column("RATE")]
        public double HourlyRate { get; set; }
    }
}
