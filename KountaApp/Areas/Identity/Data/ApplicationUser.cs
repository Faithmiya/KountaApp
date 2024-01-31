using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {


        // Additional Attributes to Owner table

        [PersonalData]
        //Adding the datatype
        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(255)")]
        public string? Address { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(255)")]
        public string? City { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(255)")]
        public string? CompanyName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Salary>? Salaries { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Income>? Incomes { get; set; }
        public ICollection<Vendor>? Vendors { get; set; }
        public ICollection<Quota>? Quotas { get; set; }
        public ICollection<Sale>? Sales { get; set; }
        public ICollection<Client>? Clients { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
