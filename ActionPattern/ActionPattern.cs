using System;

namespace Tonari.ActionPattern
{
    public static class ActionPattern<T>
    {
        public static IActionPattern<T, Action<T>> Pattern(T key, Action<T> action)
        {
            return new ActionPatternBase<T, Action<T>>(key, action);
        }

        public static IActionPattern<Func<T, bool>, Action<T>> Pattern(Func<T, bool> predicate, Action<T> action)
        {
            return new ActionPatternBase<Func<T, bool>, Action<T>>(predicate, action);
        }
    }

    public static class ActionPattern<T1, T2>
    {
        public static IActionPattern<T1, Func<T1, T2>> Pattern(T1 key, Func<T1, T2> func)
        {
            return new ActionPatternBase<T1, Func<T1, T2>>(key, func);
        }

        public static IActionPattern<T1, Action<T1, T2>> Pattern(T1 key, Action<T1, T2> action)
        {
            return new ActionPatternBase<T1, Action<T1, T2>>(key, action);
        }

        public static IActionPattern<Func<T1, bool>, Func<T1, T2>> Pattern(Func<T1, bool> predicate, Func<T1, T2> func)
        {
            return new ActionPatternBase<Func<T1, bool>, Func<T1, T2>>(predicate, func);
        }

        public static IActionPattern<Func<T1, bool>, Action<T1, T2>> Pattern(Func<T1, bool> predicate, Action<T1, T2> action)
        {
            return new ActionPatternBase<Func<T1, bool>, Action<T1, T2>>(predicate, action);
        }

        public static IActionPattern<Func<T1, T2, bool>, Action<T1, T2>> Pattern(Func<T1, T2, bool> predicate, Action<T1, T2> action)
        {
            return new ActionPatternBase<Func<T1, T2, bool>, Action<T1, T2>>(predicate, action);
        }
    }

    public static class ActionPattern<T1, T2, T3>
    {
        public static IActionPattern<T1, Func<T1, T2, T3>> Pattern(T1 key, Func<T1, T2, T3> func)
        {
            return new ActionPatternBase<T1, Func<T1, T2, T3>>(key, func);
        }

        public static IActionPattern<Func<T1, bool>, Func<T1, T2, T3>> Pattern(Func<T1, bool> predicate, Func<T1, T2, T3> func)
        {
            return new ActionPatternBase<Func<T1, bool>, Func<T1, T2, T3>>(predicate, func);
        }

        public static IActionPattern<Func<T1, T2, bool>, Func<T1, T2, T3>> Pattern(Func<T1, T2, bool> predicate, Func<T1, T2, T3> func)
        {
            return new ActionPatternBase<Func<T1, T2, bool>, Func<T1, T2, T3>>(predicate, func);
        }
    }
}