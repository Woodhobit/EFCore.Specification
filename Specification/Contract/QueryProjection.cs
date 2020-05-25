using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public abstract class QueryProjection<T, TResult>
    {
        public abstract Expression<Func<T, TResult>> ToSelectExpression();
    }
}
