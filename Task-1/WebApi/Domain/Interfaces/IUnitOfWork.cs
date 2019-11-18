using Domain.Entities;
using System;

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
