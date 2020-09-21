using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dto
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateOfrResignation { get; set; }

        public DateTime HiringDate { get; set; }

        public string ZipCode { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
