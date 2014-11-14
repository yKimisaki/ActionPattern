using System;

namespace Tonari.ActionPattern
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

    internal class ArgPredicateActionPattern<TPrimary, TSecondary>
        : ActionPatternBase<Func<TPrimary, bool>, Action<TPrimary, TSecondary>>
    {
        public ArgPredicateActionPattern(Func<TPrimary, bool> predicate, Action<TPrimary, TSecondary> action)
        {
            Patterns.Add(predicate, action);
        }
    }

    internal class ArgPredicateActionPattern<TPrimary, TSecondary, TResult>
        : ActionPatternBase<Func<TPrimary, bool>, Func<TPrimary, TSecondary, TResult>>
    {
        public ArgPredicateActionPattern(Func<TPrimary, bool> predicate, Func<TPrimary, TSecondary, TResult> action)
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
