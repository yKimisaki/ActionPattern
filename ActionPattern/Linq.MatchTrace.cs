using System;
using System.Collections.Generic;

namespace Tonari.ActionPattern
{
    public static class LinqMatchTrace
    {
        public static IEnumerable<T> MatchTrace<T>(this IEnumerable<T> source, IActionPattern<T, Action<T>> pattern)
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

        public static IEnumerable<T> MatchTrace<T>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Action<T>> pattern)
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

        public static IEnumerable<T> MatchTrace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<T, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
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

        public static IEnumerable<T> MatchTrace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
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

        public static IEnumerable<T> MatchTrace<T, TPatternArgument>(this IEnumerable<T> source, IActionPattern<Func<T, TPatternArgument, bool>, Action<T, TPatternArgument>> pattern, TPatternArgument arg)
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
