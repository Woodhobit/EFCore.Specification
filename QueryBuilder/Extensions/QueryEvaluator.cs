using QueryBuilder.Query;
using System.Linq;

namespace QueryBuilder.Extensions
{
    public static class QueryEvaluator
    {
        public static IQueryable<T> EvaluateQuery<T>(this IQueryable<T> inputQuery, Query<T> query)
        {
            if (query.Filter != null)
            {
                inputQuery = inputQuery.Where(query.Filter);
            }

            if (query.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(query.OrderBy);
            }

            if (query.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(query.OrderByDescending);
            }

            if (query.Includes.Any())
            {
                foreach (var includeExp in query.Includes)
                {
                    query.Include(includeExp);
                }
            }

            return inputQuery;
        }

        public static IQueryable<TResult> EvaluateQuery<T, TResult>(this IQueryable<T> inputQuery, QueryWithProjection<T, TResult> query)
        {
            inputQuery = EvaluateQuery<T>(inputQuery, query);

            return inputQuery.Select(query.Selector);
        }
    }
}
