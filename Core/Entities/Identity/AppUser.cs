using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public List<Address> Addresses { get; set; }
    }
}