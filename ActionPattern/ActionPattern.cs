using System.Collections.Generic;

namespace System.ActionPattern
{
    public static class ActionPattern<T>
    {
        public static IActionPattern<T, Action<T>> Pattern(T key, Action<T> action)
        {
            return new KeyActionPattern<T>(key, action);
        }

        public static IActionPattern<Func<T, bool>, Action<T>> Pattern(Func<T, bool> predicate, Action<T> action)
        {
            return new PredicateActionPattern<T>(predicate, action);
        }
    }

    public static class ActionPattern<T1, T2>
    {
        public static IActionPattern<T1, Func<T1, T2>> Pattern(T1 key, Func<T1, T2> func)
        {
            return new KeyActionPattern<T1, T2>(key, func);
        }

        public static IActionPattern<Func<T1, bool>, Func<T1, T2>> Pattern(Func<T1, bool> predicate, Func<T1, T2> func)
        {
            return new PredicateActionPattern<T1, T2>(predicate, func);
        }

        public static IActionPattern<Func<T1, T2, bool>, Action<T1, T2>> Pattern(Func<T1, T2, bool> predicate, Action<T1, T2> action)
        {
            return new TwoArgsPredicateActionPattern<T1, T2>(predicate, action);
        }

        public static ISelectedActionPattern<T1, T2, Action<T2>> Select(Func<T1, T2> selector)
        {
            return new SelectedKeyActionPattern<T1, T2>(selector);
        }
    }

    public static class ActionPattern<T1, T2, T3>
    {
        public static IActionPattern<T1, Func<T1, T2, T3>> Pattern(T1 key, Func<T1, T2, T3> func)
        {
            return new KeyActionPattern<T1, T2, T3>(key, func);
        }

        public static IActionPattern<Func<T1, bool>, Func<T1, T2, T3>> Pattern(Func<T1, bool> predicate, Func<T1, T2, T3> func)
        {
            return new PredicateActionPattern<T1, T2, T3>(predicate, func);
        }

        public static IActionPattern<Func<T1, T2, bool>, Func<T1, T2, T3>> Pattern(Func<T1, T2, bool> predicate, Func<T1, T2, T3> func)
        {
            return new TwoArgsPredicateActionPattern<T1, T2, T3>(predicate, func);
        }

        public static ISelectedActionPattern<T1, T2, Func<T2, T3>> Select(Func<T1, T2> selector)
        {
            return new SelectedKeyActionPattern<T1, T2, T3>(selector);
       } 
    }

    public static class ActionPattern<T1, T2, T3, T4>
    {
        public static ISelectedActionPattern<T1, T3, Func<T2, T4, bool>, Action<T2, T4>> Select(Func<T1, T2> primarySelector, Func<T3, T4> secondarySelector)
        {
            return new DoubleSelectedKeyActionPattern<T1, T2, T3, T4>(primarySelector, secondarySelector);
        }
    }

    public static class ActionPattern<T1, T2, T3, T4, T5>
    {
        public static ISelectedActionPattern<T1, T3, Func<T2, T4, bool>, Func<T2, T4, T5>> Select(Func<T1, T2> primarySelector, Func<T3, T4> secondarySelector)
        {
            return new DoubleSelectedKeyActionPattern<T1, T2, T3, T4, T5>(primarySelector, secondarySelector);
        }
    }
}
