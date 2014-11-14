using System;
using System.Collections.Generic;

namespace Tonari.ActionPattern
{
    public static class Linq
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

        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, IActionPattern<T, Action<T>> pattern)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    e.Current.Match(pattern);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Action<T>> pattern)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    e.Current.Match(pattern);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<T, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    e.Current.Match(pattern, arg);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    e.Current.Match(pattern, arg);
                    yield return e.Current;
                }
            }
        }

        public static IEnumerable<T> Trace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<Func<T, TPatternArgument, bool>, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    e.Current.Match(pattern, arg);
                    yield return e.Current;
                }
            }
        }
    }
}
