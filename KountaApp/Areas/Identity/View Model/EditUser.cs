using KountaApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditUser
    {
        [PersonalData]
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

        
    }
}
