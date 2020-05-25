using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace QueryBuilder
{
    public class Query<T>
    {
        public Expression<Func<T, bool>> Filter { get; private set; }
    //    public List<Expression<Func<T, object>>> Includes { get; }

        public Expression<Func<T, object>> OrderBy { get; private set; }
        //   public Expression<Func<T, object>> OrderByDescending { get; }

        public virtual void AddFilter(CompositeSpecification<T> specification)
        {
            this.Filter = specification.ToExpression();
        }

        public virtual void AddOrderBy(OrderBySpecification<T> specification)
        {
            this.OrderBy = specification.ToOrderByExpression();
        }
    }
}
