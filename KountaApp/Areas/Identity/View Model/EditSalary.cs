using KountaApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditSalary
    {
        public int SalaryId { get; set; }
        public DateTime? PayDate { get; set; }
        public decimal? Wage { get; set; }


        // Add FKs

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext


        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; } //Used in relationship configuration in the DbContext
    }
}
