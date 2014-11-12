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

    internal abstract class DoubleSelectedActionPatternBase<TPrimary, TPrimarySelected, TSecondary, TSecondarySelected, TAction>
        : ActionPatternBase<Func<TPrimarySelected, TSecondarySelected, bool>, TAction>
        , ISelectedActionPattern<TPrimary, TSecondary, Func<TPrimarySelected, TSecondarySelected, bool>, TAction> where TAction : class
    {
        protected Func<TPrimary, TPrimarySelected> Primary = null;
        protected Func<TSecondary, TSecondarySelected> Secondary = null;

        public Func<TPrimary, TPrimarySelected> GetPrimarySelecter() { return Primary; }
        public Func<TSecondary, TSecondarySelected> GetSecondaryGetPrimarySelecter() { return Secondary; }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TPrimarySelected, TSecondarySelected, bool>, TAction> Pattern(Func<TPrimarySelected, TSecondarySelected, bool> predicate, TAction action)
        {
            Patterns.Add(predicate, action);
            return this;
        }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TPrimarySelected, TSecondarySelected, bool>, TAction> CatchNull(TAction action)
        {
            CatchNullAction = action;
            return this;
        }

        public new ISelectedActionPattern<TPrimary, TSecondary, Func<TPrimarySelected, TSecondarySelected, bool>, TAction> Default(TAction action)
        {
            DefaultAction = action;
            return this;
        }

        public Func<TPrimary, TPrimarySelected> GetPrimarySelector() { return Primary; }
        public Func<TSecondary, TSecondarySelected> GetSecondarySelector() { return Secondary; }
    }
}
