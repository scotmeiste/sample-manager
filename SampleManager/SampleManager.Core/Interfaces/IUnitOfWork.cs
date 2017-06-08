using System;
using SampleManager.Core.Models;

namespace SampleManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sample> SampleRepository { get; }

        IRepository<User> UserRepository { get; }

        void Commit();
    }
}
