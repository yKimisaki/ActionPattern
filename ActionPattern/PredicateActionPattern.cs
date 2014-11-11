using System.Collections.Generic;

namespace System.ActionPattern
{
    internal class PredicateActionPattern<T> : IActionPatternGetter<Func<T, bool>, Action<T>>, IDisposable
    {
        private Dictionary<Func<T, bool>, Action<T>> patterns = new Dictionary<Func<T, bool>, Action<T>>();
        private Action<T> catchNullAction = null;
        private Action<T> defaultAction = x => { };

        public PredicateActionPattern(Func<T, bool> predicate, Action<T> action)
        {
            patterns.Add(predicate, action);
        }

        public void Dispose()
        {
            patterns = null;
            defaultAction = null;
        }

        public IDictionary<Func<T, bool>, Action<T>> GetPatterns() { return patterns; }
        public Action<T> GetCatchNull() { return catchNullAction; }
        public Action<T> GetDefault() { return defaultAction; }

        public IActionPattern<Func<T, bool>, Action<T>> Pattern(Func<T, bool> predicate, Action<T> action)
        {
            patterns.Add(predicate, action);
            return this;
        }

        public IActionPattern<Func<T, bool>, Action<T>> CatchNull(Action<T> action)
        {
            catchNullAction = action;
            return this;
        }

        public IActionPattern<Func<T, bool>, Action<T>> Default(Action<T> action)
        {
            defaultAction = action;
            return this;
        }
    }

    internal class PredicateActionPattern<T, TResult> : IActionPatternGetter<Func<T, bool>, Func<T, TResult>>, IDisposable
    {
        private Dictionary<Func<T, bool>, Func<T, TResult>> patterns = new Dictionary<Func<T, bool>, Func<T, TResult>>();
        private Func<T, TResult> catchNullAction = null;
        private Func<T, TResult> defaultAction = x => default(TResult);

        public PredicateActionPattern(Func<T, bool> predicate, Func<T, TResult> action)
        {
            patterns.Add(predicate, action);
        }

        public void Dispose()
        {
            patterns = null;
            defaultAction = null;
        }

        public IDictionary<Func<T, bool>, Func<T, TResult>> GetPatterns() { return patterns; }
        public Func<T, TResult> GetCatchNull() { return catchNullAction; }
        public Func<T, TResult> GetDefault() { return defaultAction; }

        public IActionPattern<Func<T, bool>, Func<T, TResult>> Pattern(Func<T, bool> predicate, Func<T, TResult> action)
        {
            patterns.Add(predicate, action);
            return this;
        }

        public IActionPattern<Func<T, bool>, Func<T, TResult>> CatchNull(Func<T, TResult> action)
        {
            catchNullAction = action;
            return this;
        }

        public IActionPattern<Func<T, bool>, Func<T, TResult>> Default(Func<T, TResult> action)
        {
            defaultAction = action;
            return this;
        }
    }
}
