using QueryBuilder.Query;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace QueryBuilder.Contract
{
    public interface IQueryBuilder<T>
    {
        IQueryBuilder<T> AddFilter(CompositeSpecification<T> specification);
        IQueryBuilder<T> AddOrderBy(OrderBySpecification<T> specification);
        IQueryBuilder<T> AddOrderByDescending(OrderBySpecification<T> specification);
        IQueryBuilder<T> Include(Expression<Func<T, object>> includeExpression);
        Query<T> GetQuery();
    }
}
