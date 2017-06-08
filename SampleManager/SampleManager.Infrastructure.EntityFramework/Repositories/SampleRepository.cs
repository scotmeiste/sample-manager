using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SampleManager.Core.Interfaces;
using SampleManager.Core.Models;
using SampleManager.Infrastructure.EntityFramework.Interfaces;

namespace SampleManager.Infrastructure.EntityFramework.Repositories
{
    public class SampleRepository : IRepository<Sample>
    {
        private readonly IContext _context;

        public SampleRepository(IContext context)
        {
            _context = context;
        }

        public void Add(Sample model)
        {
            _context.Samples.Add(model);
        }

        public void Remove(Sample model)
        {
            _context.Samples.Remove(model);
        }

        public IQueryable<Sample> Find(Expression<Func<Sample, bool>> predicate)
        {
            return _context.Samples.Where(predicate)
                .Include(s => s.User)
                .Include(s => s.Status);
        }
    }
}
