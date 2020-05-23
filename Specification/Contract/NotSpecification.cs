using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> specification;

        public NotSpecification(Specification<T> specification)
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
