using System;
using System.Collections.Generic;
using System.Text;

namespace Entites
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Department Department { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateOfrResignation { get; set; }

        public DateTime HiringDate { get; set; }

        public string ZipCode { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}
