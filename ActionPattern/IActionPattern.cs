using System.Collections.Generic;

namespace Tonari.ActionPattern
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
}
