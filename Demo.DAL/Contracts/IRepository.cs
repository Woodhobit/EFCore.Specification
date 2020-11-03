using Demo.DAL.Models;
using QueryBuilder;
using QueryBuilder.Query;
using Specification.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.DAL.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void AddOrUpdate(T entity);
        T Add(T entity);
        T Get(long id);
        Task<T> GetAsync(long id);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetPerPage(int perPage, int pageNumber);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void SaveChanges();
        Task SaveChangesAsync();
        IQueryable<T> Get(CompositeSpecification<T> specification);
        Task<IList<T>> QueryAsync(Query<T> query);
        Task<List<TResult>> QueryAsync<TResult>(QueryWithProjection<T, TResult> query);
    }
}
