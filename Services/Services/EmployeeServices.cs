using DataAccess;
using Entites;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class EmployeeServices : Services<Employee> , IEmployeeServices
    {
       
        private readonly StoreContext _context;

        public EmployeeServices(StoreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
