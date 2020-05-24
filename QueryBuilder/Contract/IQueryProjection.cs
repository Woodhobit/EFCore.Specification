using System;
using System.Linq.Expressions;

namespace QueryBuilder.Contract
{
    public interface IQueryProjection<T, TResult>
    {
        Expression<Func<T, TResult>> ToSelectExpression();
    }
}
