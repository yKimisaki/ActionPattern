using System;

namespace Tonari.ActionPattern
{
    public static class SimplePattern
    {
        public static T Pattern<T>(this T source, T predicate, Action<T> action)
        {
            if (!Object.Equals(source, null) && Object.Equals(source, predicate)) action(source);
            return source;
        }

        public static T Pattern<T>(this T source, Func<T, bool> predicate, Action<T> action)
        {
            if (!Object.Equals(source, null) && predicate(source)) action(source);
            return source;
        }
    }
}
