using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Specification.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly CompositeSpecification<T> left;
        private readonly CompositeSpecification<T> right;

        public AndSpecification(CompositeSpecification<T> left, CompositeSpecification<T> right)
        {
            this.right = right;
            this.left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = this.left.ToExpression();
            var rightExpression = this.right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
