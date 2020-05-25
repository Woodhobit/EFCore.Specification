using Specification.Contract;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Specification
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private readonly CompositeSpecification<T> specification;

        public NotSpecification(CompositeSpecification<T> specification)
        {
            this.specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> spec = this.specification.ToExpression();

            UnaryExpression notExpression = Expression.Not(spec);

            return Expression.Lambda<Func<T, bool>>(
                notExpression, spec.Parameters.Single());
        }
    }
}
