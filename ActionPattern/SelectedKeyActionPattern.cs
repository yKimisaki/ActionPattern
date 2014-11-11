using System.Collections.Generic;

namespace System.ActionPattern
{
    internal class SelectedKeyActionPattern<TSource, T>
        : SelectedActionPatternBase<TSource, T, Action<T>>
    {
        public SelectedKeyActionPattern(Func<TSource, T> selector)
        {
            Selector = selector;
        }
    }

    internal class SelectedKeyActionPattern<TSource, TSelected, TResult>
        : SelectedActionPatternBase<TSource, TSelected, Func<TSelected, TResult>>
    {
        public SelectedKeyActionPattern(Func<TSource, TSelected> selector)
        {
            Selector = selector;
        }
    }

    internal class DoubleSelectedKeyActionPattern<TPrimary, TSecondary, TSelected>
        : DoubleSelectedActionPatternBase<TPrimary, TSecondary, TSelected, Action<TSelected, TSelected>>
    {
        public DoubleSelectedKeyActionPattern(Func<TPrimary, TSelected> primary, Func<TSecondary, TSelected> secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }
    }

    internal class DoubleSelectedKeyActionPattern<TPrimary, TSecondary, TSelected, TResult>
        : DoubleSelectedActionPatternBase<TPrimary, TSecondary, TSelected, Func<TSelected, TSelected, TResult>>
    {
        public DoubleSelectedKeyActionPattern(Func<TPrimary, TSelected> primary, Func<TSecondary, TSelected> secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }
    }
}
