using KountaApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditIncome
    {
        public int IncomeId { get; set; }

        public string? Category { get; set; }

        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext
    }
}
