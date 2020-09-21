using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IEmployeeServices : IServices<Employee>
    {
        void Update(Employee employee);
    }
}
