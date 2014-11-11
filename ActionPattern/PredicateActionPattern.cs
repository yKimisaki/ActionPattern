using System.Collections.Generic;

namespace System.ActionPattern
{
    internal class PredicateActionPattern<T>
        : ActionPatternBase<Func<T, bool>, Action<T>>
    {
        public PredicateActionPattern(Func<T, bool> predicate, Action<T> action)
        {
            Patterns.Add(predicate, action);
        }
    }

    internal class PredicateActionPattern<T, TResult>
        : ActionPatternBase<Func<T, bool>, Func<T, TResult>>
    {
        public PredicateActionPattern(Func<T, bool> predicate, Func<T, TResult> action)
        {
            Patterns.Add(predicate, action);
        }
    }

    internal class PredicateActionPattern<T, TArgument, TResult>
        : ActionPatternBase<Func<T, bool>, Func<T, TArgument, TResult>>
    {
        public PredicateActionPattern(Func<T, bool> predicate, Func<T, TArgument, TResult> action)
        {
            Patterns.Add(predicate, action);
        }
    }
}
