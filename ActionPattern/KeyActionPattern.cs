using System.Collections.Generic;

namespace System.ActionPattern
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

    internal class KeyActionPattern<TPrimary, TSecondary, TResult>
        : ActionPatternBase<TPrimary, Func<TPrimary, TSecondary, TResult>>
    {
        public KeyActionPattern(TPrimary key, Func<TPrimary, TSecondary, TResult> action)
        {
            Patterns.Add(key, action);
        }
    }
}
