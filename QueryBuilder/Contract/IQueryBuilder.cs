using Specification.Contract;

namespace QueryBuilder.Contract
{
    public interface IQueryBuilder<T>
    {
        IQueryBuilder<T> AddFilter(CompositeSpecification<T> specification);
        IQueryBuilder<T> AddOrderBy(OrderBySpecification<T> specification);
        //  IQueryBuilder AddInclude();
        Query<T> GetQuery();
    }
}
