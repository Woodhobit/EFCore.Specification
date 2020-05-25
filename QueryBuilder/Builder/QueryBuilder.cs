using QueryBuilder.Contract;
using QueryBuilder.Query;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace QueryBuilder.Builder
{
    public class QueryBuilder<T> : IQueryBuilder<T>
    {
        private readonly Query<T> query;

        public QueryBuilder()
        {
            this.query = new Query<T>();
        }

        public QueryBuilder(CompositeSpecification<T> specification): base()
        {
            this.query.AddFilter(specification);
        }

        public IQueryBuilder<T> AddFilter(CompositeSpecification<T> specification)
        {
            this.query.AddFilter(specification);
            return this;
        }

        public IQueryBuilder<T> AddOrderBy(OrderBySpecification<T> specification)
        {
            this.query.AddOrderBy(specification);
            return this;
        }

        public IQueryBuilder<T> AddOrderByDescending(OrderBySpecification<T> specification)
        {
            this.query.AddOrderByDescending(specification);
            return this;
        }

        public IQueryBuilder<T> Include(Expression<Func<T, object>> includeExpression)
        {
            this.query.Include(includeExpression);
            return this;
        }

        public Query<T> GetQuery()
        {
            return this.query;
        }
    }
}
