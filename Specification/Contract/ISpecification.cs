using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }
}