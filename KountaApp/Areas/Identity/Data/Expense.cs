using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.Data
{
    public class Expense
    {

        [Key]
        public int ExpenseId { get; set; }
        public string? Category { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext

    }
}
