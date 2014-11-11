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

    internal class KeyActionPattern<T, TArgument, TResult>
        : ActionPatternBase<T, Func<T, TArgument, TResult>>
    {
        public KeyActionPattern(T key, Func<T, TArgument, TResult> action)
        {
            Patterns.Add(key, action);
        }
    }
}
