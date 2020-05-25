using Specification.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QueryBuilder.Query
{
    public class Query<T>
    {
        public Expression<Func<T, bool>> Filter { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; private set; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public Query()
        {
                this.Includes = new List<Expression<Func<T, object>>>();
        }

        public virtual void AddFilter(CompositeSpecification<T> specification)
        {
            this.Filter = specification.ToExpression();
        }

        public virtual void AddOrderBy(OrderBySpecification<T> specification)
        {
            this.OrderBy = specification.ToOrderByExpression();
        }

        public virtual void AddOrderByDescending(OrderBySpecification<T> specification)
        {
            this.OrderByDescending = specification.ToOrderByExpression();
        }

        public virtual void Include(Expression<Func<T, object>> includeExpression)
        {
            this.Includes.Add(includeExpression);
        }
    }
}
