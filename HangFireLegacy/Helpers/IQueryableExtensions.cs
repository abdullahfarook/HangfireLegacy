using System;
using System.Linq;
using System.Linq.Expressions;

namespace HangFireLegacy.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> predicate)

            => condition ? source.Where(predicate) : source;
    }
}
