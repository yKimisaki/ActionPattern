using System;
using System.Collections.Generic;

namespace Tonari.ActionPattern
{
    internal class ActionPatternBase<TKey, TAction>
        : IActionPattern<TKey, TAction>
        , IActionPatternGetter<TKey, TAction>
        , IDisposable where TAction : class
    {
        protected Dictionary<TKey, TAction> Patterns = new Dictionary<TKey, TAction>();
        protected TAction CatchNullAction = null;
        protected TAction DefaultAction = null;

        public ActionPatternBase(TKey key, TAction action)
        {
            Patterns.Add(key, action);
        }
        
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
}
