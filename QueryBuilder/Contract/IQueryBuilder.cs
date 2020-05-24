using Specification.Contract;

namespace QueryBuilder.Contract
{
    public interface IQueryBuilder<T>
    {
        IQueryBuilder<T> AddFilter(ISpecification<T> specification);
        IQueryBuilder<T> AddOrderBy(ISpecification<T> specification);
        //  IQueryBuilder AddInclude();
        Query<T> GetQuery();
    }
}
