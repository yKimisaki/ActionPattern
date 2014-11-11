using System.Collections.Generic;

namespace System.ActionPattern
{
    internal abstract class ActionPatternBase<TKey, TAction>
        : IActionPattern<TKey, TAction>
        , IActionPatternGetter<TKey, TAction>
        , IDisposable where TAction : class
    {
        protected Dictionary<TKey, TAction> Patterns = new Dictionary<TKey, TAction>();
        protected TAction catchNullAction = null;
        protected TAction defaultAction = null;
        
        public void Dispose()
        {
            catchNullAction = null;
            defaultAction = null;
        }

        public IDictionary<TKey, TAction> GetPatterns() { return Patterns; }
        public TAction GetCatchNull() { return catchNullAction; }
        public TAction GetDefault() { return defaultAction; }

        public IActionPattern<TKey, TAction> Pattern(TKey predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public IActionPattern<TKey, TAction> CatchNull(TAction action)
        {
            catchNullAction = action;
            return this;
        }

        public IActionPattern<TKey, TAction> Default(TAction action)
        {
            defaultAction = action;
            return this;
        }
    }

    internal abstract class SelectedActionPatternBase<TSource, TKey, TAction>
        : ActionPatternBase<TKey, TAction>
        , ISelectedActionPattern<TSource, TKey, TAction>
        , ISelectedActionPatternGetter<TSource, TKey, TAction>
        where TAction : class
    {
        protected Func<TSource, TKey> Selector = null;
        
        public Func<TSource, TKey> GetSelector() { return Selector; }

        public new ISelectedActionPattern<TSource, TKey, TAction> Pattern(TKey predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public new ISelectedActionPattern<TSource, TKey, TAction> CatchNull(TAction action)
        {
            catchNullAction = action;
            return this;
        }

        public new ISelectedActionPattern<TSource, TKey, TAction> Default(TAction action)
        {
            defaultAction = action;
            return this;
        }
    }
}
