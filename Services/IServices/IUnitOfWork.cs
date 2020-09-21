using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeServices Employee { get; }

        void Save();
    }
}
