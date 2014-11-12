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

    internal class TwoArgsPredicateActionPattern<TPrimary, TSecondary>
        : ActionPatternBase<Func<TPrimary, TSecondary, bool>, Action<TPrimary, TSecondary>>
    {
        public TwoArgsPredicateActionPattern(Func<TPrimary, TSecondary, bool> predicate, Action<TPrimary, TSecondary> action)
        {
            Patterns.Add(predicate, action);
        }
    }

    internal class TwoArgsPredicateActionPattern<TPrimary, TSecondary, TResult>
        : ActionPatternBase<Func<TPrimary, TSecondary, bool>, Func<TPrimary, TSecondary, TResult>>
    {
        public TwoArgsPredicateActionPattern(Func<TPrimary, TSecondary, bool> predicate, Func<TPrimary, TSecondary, TResult> action)
        {
            Patterns.Add(predicate, action);
        }
    }
}
