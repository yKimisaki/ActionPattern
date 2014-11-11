using System.Collections.Generic;

namespace System.ActionPattern
{
    internal class SelectedKeyActionPattern<TSource, T> : ISelectedActionPatternGetter<TSource, T, Action<T>>, IDisposable
    {
        private Func<TSource, T> selector = null;
        private Dictionary<T, Action<T>> patterns = new Dictionary<T, Action<T>>();
        private Action<T> catchNullAction = null;
        private Action<T> defaultAction = x => { };

        public SelectedKeyActionPattern(Func<TSource, T> selector)
        {
            this.selector = selector;
        }

        public void Dispose()
        {
            selector = null;
        }

        public Func<TSource, T> GetSelector() { return selector; }
        public IDictionary<T, Action<T>> GetPatterns() { return patterns; }
        public Action<T> GetCatchNull() { return catchNullAction; }
        public Action<T> GetDefault() { return defaultAction; }

        public ISelectedActionPattern<TSource, T, Action<T>> Pattern(T predicate, Action<T> action)
        {
            patterns.Add(predicate, action);
            return this;
        }

        public ISelectedActionPattern<TSource, T, Action<T>> CatchNull(Action<T> action)
        {
            catchNullAction = action;
            return this;
        }

        public ISelectedActionPattern<TSource, T, Action<T>> Default(Action<T> action)
        {
            defaultAction = action;
            return this;
        }
    }

    internal class SelectedKeyActionPattern<TSource, T, TResult> : ISelectedActionPatternGetter<TSource, T, Func<T, TResult>>, IDisposable
    {
        private Func<TSource, T> selector = null;
        private Dictionary<T, Func<T, TResult>> patterns = new Dictionary<T, Func<T, TResult>>();
        private Func<T, TResult> catchNullAction = null;
        private Func<T, TResult> defaultAction = x => default(TResult);

        public SelectedKeyActionPattern(Func<TSource, T> selector)
        {
            this.selector = selector;
        }

        public void Dispose()
        {
            selector = null;
        }

        public Func<TSource, T> GetSelector() { return selector; }
        public IDictionary<T, Func<T, TResult>> GetPatterns() { return patterns; }
        public Func<T, TResult> GetCatchNull() { return catchNullAction; }
        public Func<T, TResult> GetDefault() { return defaultAction; }

        public ISelectedActionPattern<TSource, T, Func<T, TResult>> Pattern(T predicate, Func<T, TResult> action)
        {
            patterns.Add(predicate, action);
            return this;
        }

        public ISelectedActionPattern<TSource, T, Func<T, TResult>> CatchNull(Func<T, TResult> action)
        {
            catchNullAction = action;
            return this;
        }

        public ISelectedActionPattern<TSource, T, Func<T, TResult>> Default(Func<T, TResult> action)
        {
            defaultAction = action;
            return this;
        }
    }
}
