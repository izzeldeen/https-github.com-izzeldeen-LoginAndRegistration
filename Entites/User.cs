using Microsoft.AspNetCore.Identity;
using System;

namespace Entites
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Gender { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string zipCode { get; set; }

        public string StreetAddress { get; set; }

        public Department Department { get; set; }
    }
}
