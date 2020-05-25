using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public abstract class OrderBySpecification<T>
    {
        public abstract Expression<Func<T, object>> ToOrderByExpression();
    }
}
