using DataAccess;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Employee = new EmployeeServices(_context);
        }

        public IEmployeeServices Employee { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
