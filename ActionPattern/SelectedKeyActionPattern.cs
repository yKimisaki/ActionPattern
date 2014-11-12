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

    internal class DoubleSelectedKeyActionPattern<TPrimary, TPrimarySelected, TSecondary, TSecondarySelected>
        : DoubleSelectedActionPatternBase<TPrimary, TPrimarySelected, TSecondary, TSecondarySelected, Action<TPrimarySelected, TSecondarySelected>>
    {
        public DoubleSelectedKeyActionPattern(Func<TPrimary, TPrimarySelected> primary, Func<TSecondary, TSecondarySelected> secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }
    }

    internal class DoubleSelectedKeyActionPattern<TPrimary, TPrimarySelected, TSecondary, TSecondarySelected, TResult>
        : DoubleSelectedActionPatternBase<TPrimary, TPrimarySelected, TSecondary, TSecondarySelected, Func<TPrimarySelected, TSecondarySelected, TResult>>
    {
        public DoubleSelectedKeyActionPattern(Func<TPrimary, TPrimarySelected> primary, Func<TSecondary, TSecondarySelected> secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }
    }
}
