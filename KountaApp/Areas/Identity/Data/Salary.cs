using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class Salary
    {

        [Key]
        public int SalaryId { get; set; }
        public DateTime? PayDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Wage { get; set; }


        // Add FKs

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

   
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; } //Used in relationship configuration in the DbContext

    }
}
