using KountaApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditProduct
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public decimal? ProductPrice { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext
    }
}
