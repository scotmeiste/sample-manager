using System;
using System.Linq;
using System.Linq.Expressions;

namespace SampleManager.Core.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        void Add(TModel model);
        void Remove(TModel model);

        IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate);
    }
}
