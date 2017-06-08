using System;
using Microsoft.EntityFrameworkCore;
using SampleManager.Core.Models;

namespace SampleManager.Infrastructure.EntityFramework.Interfaces
{
    public interface IContext : IDisposable
    {
        DbSet<Sample> Samples { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
