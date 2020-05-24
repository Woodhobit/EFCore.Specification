using QueryBuilder.Contract;
using Specification.Contract;

namespace QueryBuilder
{
    public class QueryBuilder<T> : IQueryBuilder<T>
    {
        private readonly Query<T> query;

        public QueryBuilder()
        {
            this.query = new Query<T>();
        }

        public QueryBuilder(ISpecification<T> specification): base()
        {
            this.query.AddFilter(specification);
        }

        public IQueryBuilder<T> AddFilter(ISpecification<T> specification)
        {
            this.query.AddFilter(specification);
            return this;
        }

        public IQueryBuilder<T> AddOrderBy(ISpecification<T> specification)
        {
            this.query.AddOrderBy(specification);
            return this;
        }

        public Query<T> GetQuery()
        {
            return this.query;
        }
    }
}
