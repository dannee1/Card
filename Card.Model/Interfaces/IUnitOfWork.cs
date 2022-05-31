using System;
using System.Collections.Generic;
using System.Text;

namespace Card.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
