using System.Collections.Generic;

namespace System.ActionPattern
{
    internal abstract class ActionPatternBase<TKey, TAction>
        : IActionPattern<TKey, TAction>
        , IActionPatternGetter<TKey, TAction>
        , IDisposable where TAction : class
    {
        protected Dictionary<TKey, TAction> Patterns = new Dictionary<TKey, TAction>();
        protected TAction CatchNullAction = null;
        protected TAction DefaultAction = null;
        
        public void Dispose()
        {
            CatchNullAction = null;
            DefaultAction = null;
        }

        public IDictionary<TKey, TAction> GetPatterns() { return Patterns; }
        public TAction GetCatchNull() { return CatchNullAction; }
        public TAction GetDefault() { return DefaultAction; }

        public IActionPattern<TKey, TAction> Pattern(TKey predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public IActionPattern<TKey, TAction> CatchNull(TAction action)
        {
            CatchNullAction = action;
            return this;
        }

        public IActionPattern<TKey, TAction> Default(TAction action)
        {
            DefaultAction = action;
            return this;
        }
    }

    internal abstract class SelectedActionPatternBase<TSource, TSelected, TAction>
        : ActionPatternBase<TSelected, TAction>
        , ISelectedActionPattern<TSource, TSelected, TAction>
        , ISelectedActionPatternGetter<TSource, TSelected, TAction>
        where TAction : class
    {
        protected Func<TSource, TSelected> Selector = null;
        
        public Func<TSource, TSelected> GetSelector() { return Selector; }

        public new ISelectedActionPattern<TSource, TSelected, TAction> Pattern(TSelected predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public new ISelectedActionPattern<TSource, TSelected, TAction> CatchNull(TAction action)
        {
            CatchNullAction = action;
            return this;
        }

        public new ISelectedActionPattern<TSource, TSelected, TAction> Default(TAction action)
        {
            DefaultAction = action;
            return this;
        }
    }

    internal abstract class DoubleSelectedActionPatternBase<TPrimary, TSecondary, TSelected, TAction>
        : ActionPatternBase<Func<TSelected, TSelected, bool>, TAction>
        , ISelectedActionPattern<TPrimary, TSecondary, Func<TSelected, TSelected, bool>, TAction> where TAction : class
    {
        protected Func<TPrimary, TSelected> Primary = null;
        protected Func<TSecondary, TSelected> Secondary = null;

        public Func<TPrimary, TSelected> GetPrimarySelecter() { return Primary; }
        public Func<TSecondary, TSelected> GetSecondaryGetPrimarySelecter() { return Secondary; }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TSelected, TSelected, bool>, TAction> Pattern(Func<TSelected, TSelected, bool> predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TSelected, TSelected, bool>, TAction> CatchNull(TAction action)
        {
            CatchNullAction = action;
            return this;
        }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TSelected, TSelected, bool>, TAction> Default(TAction action)
        {
            DefaultAction = action;
            return this;
        }

        public Func<TPrimary, TSelected> GetPrimarySelector() { return Primary; }

        public Func<TSecondary, TSelected> GetSecondarySelector() { return Secondary; }
    }
}
