using System.Linq;

namespace QueryBuilder.Extensions
{
    public static class QueryEvaluator
    {
        public static IQueryable<T> EvaluateQuery<T>(this IQueryable<T> inputQuery, Query<T> query)
        {

            // modify the IQueryable using the query's filter expression
            if (query.Filter != null)
            {
                inputQuery = inputQuery.Where(query.Filter);
            }

            if (query.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(query.OrderBy);
            }

            return inputQuery;
        }
    }
}
