using System.Collections.Generic;
using System.Linq;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// LINQ Extensions
    /// </summary>
    internal static class LinqExtensions
    {
        /// <summary>
        /// Batch
        /// </summary>
        /// <typeparam name="TSource">Source Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="size">Size</param>
        /// <returns>Batches</returns>
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
                  this IEnumerable<TSource> source, int size)
        {
            var count = 0;
            TSource[] bucket = null;
            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];
                bucket[count++] = item;
                if (count != size)
                    continue;
                yield return bucket;
                bucket = null;
                count = 0;
            }
            if (bucket != null && count > 0)
                yield return bucket.Take(count).ToArray();
        }
    }
}
