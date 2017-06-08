using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Infrastructure.EntityFramework.Interfaces;
using SampleManager.Infrastructure.EntityFramework.Repositories;

namespace SampleManager.Infrastructure.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        private IRepository<Sample> _sampleRepository;
        private IRepository<User> _userRepository;

        public EfUnitOfWork(EfContext context)
        {
            _context = context;
        }

        public IRepository<Sample> SampleRepository => _sampleRepository ?? (_sampleRepository = new SampleRepository(_context));
        public IRepository<User> UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
