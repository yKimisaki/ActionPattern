using System.Collections.Generic;

namespace System.ActionPattern
{
    public interface IActionPattern<TPredicate, TAction>
    {
        IActionPattern<TPredicate, TAction> Pattern(TPredicate predicate, TAction action);
        IActionPattern<TPredicate, TAction> CatchNull(TAction action);
        IActionPattern<TPredicate, TAction> Default(TAction action);
    }

    internal interface IActionPatternGetter<TPredicate, TAction>
    {
        IDictionary<TPredicate, TAction> GetPatterns();
        TAction GetCatchNull();
        TAction GetDefault();
    }

    public interface ISelectedActionPattern<TSource, TSelected, TAction>
    {
        ISelectedActionPattern<TSource, TSelected, TAction> Pattern(TSelected predicate, TAction action);
        ISelectedActionPattern<TSource, TSelected, TAction> CatchNull(TAction action);
        ISelectedActionPattern<TSource, TSelected, TAction> Default(TAction action);
    }

    internal interface ISelectedActionPatternGetter<TSource, TSelected, TAction> : IActionPatternGetter<TSelected, TAction>
    {
        Func<TSource, TSelected> GetSelector();
    }

    public interface ISelectedActionPattern<TPrimary, TSecondary, TSelected, TAction>
    {
        ISelectedActionPattern<TPrimary, TSecondary, TSelected, TAction> Pattern(TSelected predicate, TAction action);
        ISelectedActionPattern<TPrimary, TSecondary, TSelected, TAction> CatchNull(TAction action);
        ISelectedActionPattern<TPrimary, TSecondary, TSelected, TAction> Default(TAction action);
    }

    internal interface ISelectedActionPatternGetter<TPrimary, TSecondary, TSelected, TAction> : IActionPatternGetter<TSelected, TAction>
    {
        Func<TPrimary, TSelected> GetPrimarySelector();
        Func<TSecondary, TSelected> GetSecondarySelector();
    }
}
