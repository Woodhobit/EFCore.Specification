using System;
using System.Linq.Expressions;

namespace Specification.Contract
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public CompositeSpecification<T> And(CompositeSpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public CompositeSpecification<T> Or(CompositeSpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public CompositeSpecification<T> Not(CompositeSpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}
