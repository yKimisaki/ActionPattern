using System;
using System.Collections.Generic;

namespace Tonari.ActionPattern
{
    public static class LinqTrace
    {
        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, Action<T> action)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    action(e.Current);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, object key, Action<T> action)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (key.Equals(e.Current))
                        action(e.Current);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, T key, Action<T> action) where T : IEquatable<T>
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.Equals(key))
                        action(e.Current);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, Func<T, bool> predicate, Action<T> action)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (predicate(e.Current))
                        action(e.Current);
                    yield return e.Current;
                }
            }
        }
    }
}
