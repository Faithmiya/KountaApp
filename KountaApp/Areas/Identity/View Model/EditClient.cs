﻿using KountaApp.Areas.Identity.Data;

namespace KountaApp.Areas.Identity.View_Model
{
    public class EditClient
    {
        public int ClientId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }


        public string? Address { get; set; }

        public DateTime? StartDate { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; } //Used in relationship configuration in the DbContext
    }
}
