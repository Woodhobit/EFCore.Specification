﻿using QueryBuilder.Contract;
using System;
using System.Linq.Expressions;

namespace QueryBuilder
{
    public class QueryWithProjection<T, TResult> : Query<T>
    {
        public Expression<Func<T, TResult>> Selector { get; private set; }

        public virtual void AddSelector(IQueryProjection<T, TResult> specification)
        {
            this.Selector = specification.ToSelectExpression();
        }
    }
}