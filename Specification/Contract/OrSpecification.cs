using System;
using System.Linq;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            this.right = right;
            this.left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = this.left.ToExpression();
            Expression<Func<T, bool>> rightExpression = this.right.ToExpression();

            BinaryExpression orExpression = Expression.OrElse(
                leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(
                orExpression, leftExpression.Parameters.Single());
        }
    }
}
