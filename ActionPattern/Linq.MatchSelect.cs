using System;
using System.Collections.Generic;

namespace Tonari.ActionPattern
{
    public static class LinqMatchSelect
    {
        public static IEnumerable<TResult> MatchSelect<T, TResult>(this IEnumerable<T> source, IActionPattern<T, Func<T, TResult>> pattern)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Match(pattern);
                }
            }
        }

        public static IEnumerable<TResult> MatchSelect<T, TResult>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Func<T, TResult>> pattern)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Match(pattern);
                }
            }
        }

        public static IEnumerable<TResult> MatchSelect<T, TPatternArgument, TResult>(this IEnumerable<T> source, IActionPattern<T, Func<T, TPatternArgument, TResult>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Match(pattern, arg);
                }
            }
        }

        public static IEnumerable<TResult> MatchSelect<T, TPatternArgument, TResult>(this IEnumerable<T> source, IActionPattern<Func<T, bool>, Func<T, TPatternArgument, TResult>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Match(pattern, arg);
                }
            }
        }

        public static IEnumerable<TResult> MatchSelect<T, TPatternArgument, TResult>(this IEnumerable<T> source, IActionPattern<Func<T, TPatternArgument, bool>, Func<T, TPatternArgument, TResult>> pattern, TPatternArgument arg)
        {
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    yield return e.Current.Match(pattern, arg);
                }
            }
        }
    }
}
