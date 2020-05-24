using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly CompositeSpecification<T> left;
        private readonly CompositeSpecification<T> right;

        public OrSpecification(CompositeSpecification<T> left, CompositeSpecification<T> right)
        {
            this.right = right;
            this.left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = this.left.ToExpression();
            var rightExpression = this.right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
