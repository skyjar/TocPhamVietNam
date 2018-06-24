namespace Infrastructure.Identity.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string Address { get; set; }
        
        public DateTime DateOfBirth { get; set; }

    }
}
