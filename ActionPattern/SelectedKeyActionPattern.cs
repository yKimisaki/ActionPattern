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

    internal class SelectedKeyActionPattern<TSource, T, TResult>
        : SelectedActionPatternBase<TSource, T, Func<T, TResult>>
    {
        public SelectedKeyActionPattern(Func<TSource, T> selector)
        {
            Selector = selector;
        }
    }
}
