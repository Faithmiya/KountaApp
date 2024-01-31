using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KountaApp.Areas.Identity.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Position { get; set; }

        // FKs

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext


        // Relationships with (this model Exists as  fk in these models)
        public ICollection<Salary>? Salaries { get; set; }

    }
}
