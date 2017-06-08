using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Infrastructure.EntityFramework.Interfaces;

namespace SampleManager.Infrastructure.EntityFramework.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public void Add(User model)
        {
            _context.Users.Add(model);
        }

        public void Remove(User model)
        {
            _context.Users.Remove(model);
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate)
                .Include(user => user.Samples)
                .ThenInclude(sample => sample.Status);

        }
    }
}
