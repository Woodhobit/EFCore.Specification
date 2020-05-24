using QueryBuilder.Contract;
using Specification.Contract;

namespace QueryBuilder
{
    public class QueryWithProjectionBuilder<T, TResult> 
    {
        private readonly QueryWithProjection<T, TResult> query;

        public QueryWithProjectionBuilder()
        {
            this.query = new QueryWithProjection<T, TResult>();
        }

        public QueryWithProjectionBuilder(ISpecification<T> specification) : base()
        {
            this.query.AddFilter(specification);
        }

        public QueryWithProjectionBuilder<T, TResult> AddFilter(ISpecification<T> specification)
        {
            this.query.AddFilter(specification);
            return this;
        }

        public QueryWithProjectionBuilder<T, TResult> AddOrderBy(ISpecification<T> specification)
        {
            this.query.AddOrderBy(specification);
            return this;
        }

        public QueryWithProjectionBuilder<T, TResult> AddSelector(IQueryProjection<T, TResult> specification)
        {
            this.query.AddSelector(specification);
            return this;
        }

        public QueryWithProjection<T, TResult> GetQuery()
        {
            return this.query;
        }
    }
}
