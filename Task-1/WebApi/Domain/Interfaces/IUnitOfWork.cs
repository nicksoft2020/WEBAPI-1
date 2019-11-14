using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    /// <summary>
    /// Gives access to repositories.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
    }
}
