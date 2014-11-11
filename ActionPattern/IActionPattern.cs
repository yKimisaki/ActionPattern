using System.Collections.Generic;

namespace System.ActionPattern
{
    public interface IActionPattern<TPredicate, TAction>
    {
        IActionPattern<TPredicate, TAction> Pattern(TPredicate predicate, TAction action);
        IActionPattern<TPredicate, TAction> CatchNull(TAction action);
        IActionPattern<TPredicate, TAction> Default(TAction action);
    }

    internal interface IActionPatternGetter<TPredicate, TAction> : IActionPattern<TPredicate, TAction>
    {
        IDictionary<TPredicate, TAction> GetPatterns();
        TAction GetCatchNull();
        TAction GetDefault();
    }

    public interface ISelectedActionPattern<TSource, TPredicate, TAction>
    {
        ISelectedActionPattern<TSource, TPredicate, TAction> Pattern(TPredicate predicate, TAction action);
        ISelectedActionPattern<TSource, TPredicate, TAction> CatchNull(TAction action);
        ISelectedActionPattern<TSource, TPredicate, TAction> Default(TAction action);
    }

    internal interface ISelectedActionPatternGetter<TSource, TPredicate, TAction> : ISelectedActionPattern<TSource, TPredicate, TAction>
    {
        Func<TSource, TPredicate> GetSelector();
        IDictionary<TPredicate, TAction> GetPatterns();
        TAction GetCatchNull();
        TAction GetDefault();
    }
}
