using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATG.Libraries.TypeHelpers
{
    public static class LinqExtensions
    {
        public static async Task<IEnumerable<T>> WhereAsync<T>(this IEnumerable<T> target, Func<T, Task<bool>> predicateAsync)
        {
            var tasks = target.Select(async x => new { Predicate = await predicateAsync(x).ConfigureAwait(false), Value = x }).ToArray();
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);

            return results.Where(x => x.Predicate).Select(x => x.Value);
        }
    }
}