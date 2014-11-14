using System;

namespace Tonari.ActionPattern
{
    internal class KeyActionPattern<T> 
        :  ActionPatternBase<T, Action<T>>
    {
        public KeyActionPattern(T key, Action<T> action)
        {
            Patterns.Add(key, action);
        }
    }

    internal class KeyActionPattern<T, TResult>
        : ActionPatternBase<T, Func<T, TResult>>
    {
        public KeyActionPattern(T key, Func<T, TResult> action)
        {
            Patterns.Add(key, action);
        }
    }

    internal class TwoArgsKeyActionPattern<TPrimary, TSecondary>
        : ActionPatternBase<TPrimary, Action<TPrimary, TSecondary>>
    {
        public TwoArgsKeyActionPattern(TPrimary key, Action<TPrimary, TSecondary> action)
        {
            Patterns.Add(key, action);
        }
    }

    internal class TwoArgsKeyActionPattern<TPrimary, TSecondary, TResult>
        : ActionPatternBase<TPrimary, Func<TPrimary, TSecondary, TResult>>
    {
        public TwoArgsKeyActionPattern(TPrimary key, Func<TPrimary, TSecondary, TResult> action)
        {
            Patterns.Add(key, action);
        }
    }
}
