
namespace System.ActionPattern
{
    public static class ActionPatternMatch
    {
        public static Action Match<T>(this T source, IActionPattern<T, Action<T>> pattern)
        {
            var p = pattern as IActionPatternGetter<T, Action<T>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            if (p.GetPatterns().ContainsKey(source))
                return () => p.GetPatterns()[source](source);

            return () => p.GetDefault()(source);
        }

        public static Func<TResult> Match<T, TResult>(this T source, IActionPattern<T, Func<T, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<T, Func<T, TResult>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            if (p.GetPatterns().ContainsKey(source))
                return () => p.GetPatterns()[source](source);

            return () => p.GetDefault()(source);
        }

        public static Action Match<T>(this T source, IActionPattern<Func<T, bool>, Action<T>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<T, bool>, Action<T>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return () => x.Value(source);

            return () => p.GetDefault()(source);
        }

        public static Func<TResult> Match<T, TResult>(this T source, IActionPattern<Func<T, bool>, Func<T, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<T, bool>, Func<T, TResult>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return () => x.Value(source);

            return () => p.GetDefault()(source);
        }

        public static Action Match<TSource, T>(this TSource source, ISelectedActionPattern<TSource, T, Action<T>> pattern)
        {
            var p = pattern as ISelectedActionPatternGetter<TSource, T, Action<T>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            var selected = p.GetSelector()(source);
            if (p.GetPatterns().ContainsKey(selected))
                return () => p.GetPatterns()[selected](selected);

            return () => p.GetDefault()(selected);
        }

        public static Func<TResult> Match<TSource, T, TResult>(this TSource source, ISelectedActionPattern<TSource, T, Func<T, TResult>> pattern)
        {
            var p = pattern as ISelectedActionPatternGetter<TSource, T, Func<T, TResult>>;

            if (p == null)
                throw new Exception();

            if (ReferenceEquals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault())(default(T));

            var selected = p.GetSelector()(source);
            if (p.GetPatterns().ContainsKey(selected))
                return () => p.GetPatterns()[selected](selected);

            return () => p.GetDefault()(selected);
        }
    }
}
