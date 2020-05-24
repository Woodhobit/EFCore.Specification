using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public abstract class OrderBySpecification<T> : ISpecification<T>
    {
        private CompositeSpecification<T> specification;

        public OrderBySpecification(CompositeSpecification<T> specification)
        {
            this.specification = specification;
        }

        public abstract Expression<Func<T, object>> ToOrderByExpression();

        public Expression<Func<T, bool>> ToExpression()
        {
            return this.specification.ToExpression();
        }
    }
}
