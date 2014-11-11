using System.Collections.Generic;

namespace System.ActionPattern
{
    public static class ActionPattern
    {
        public static IActionPattern<T, Action<T>> Pattern<T>(T key, Action<T> action)
        {
            return new KeyActionPattern<T>(key, action);
        }

        public static IActionPattern<T, Func<T, TResult>> Pattern<T, TResult>(T key, Func<T, TResult> func)
        {
            return new KeyActionPattern<T, TResult>(key, func);
        }
    }

    public static class ActionPattern<T>
    {
        public static IActionPattern<Func<T, bool>, Action<T>> Pattern(Func<T, bool> predicate, Action<T> action)
        {
            return new PredicateActionPattern<T>(predicate, action);
        }

        public static IActionPattern<Func<T, bool>, Func<T, TResult>> Pattern<TResult>(Func<T, bool> predicate, Func<T, TResult> func)
        {
            return new PredicateActionPattern<T, TResult>(predicate, func);
        }

        public static ISelectedActionPattern<T, TSelected, Action<TSelected>> Select<TSelected>(Func<T, TSelected> selector)
        {
            return new SelectedKeyActionPattern<T, TSelected>(selector);
        }
    }

    public static class ActionPattern<T, TSelected, TResult>
    {
        public static ISelectedActionPattern<T, TSelected, Func<TSelected, TResult>> Select(Func<T, TSelected> selector)
        {
            return new SelectedKeyActionPattern<T, TSelected, TResult>(selector);
        }
    }
}
