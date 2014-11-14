using System;

namespace Tonari.ActionPattern
{
    public static class ActionPatternMatch
    {
        public static Action Match<T>(this T source, IActionPattern<T, Action<T>> pattern)
        {
            var p = pattern as IActionPatternGetter<T, Action<T>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault() ?? (x => { }))(default(T));

            if (p.GetPatterns().ContainsKey(source))
                return () => p.GetPatterns()[source](source);

            return () => (p.GetDefault() ?? (x => { }))(source);
        }

        public static Func<TResult> Match<T, TResult>(this T source, IActionPattern<T, Func<T, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<T, Func<T, TResult>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault() ?? (x => default(TResult)))(default(T));

            if (p.GetPatterns().ContainsKey(source))
                return () => p.GetPatterns()[source](source);

            return () => (p.GetDefault() ?? (x => default(TResult)))(source);
        }

        public static Func<TSecondary, TResult> Match<TPrimary, TSecondary, TResult>(this TPrimary source, IActionPattern<TPrimary, Func<TPrimary, TSecondary, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<TPrimary, Func<TPrimary, TSecondary, TResult>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return arg => (p.GetCatchNull() ?? p.GetDefault() ?? ((x, y) => default(TResult)))(default(TPrimary), arg);

            if (p.GetPatterns().ContainsKey(source))
                return arg => p.GetPatterns()[source](source, arg);

            return arg => (p.GetDefault() ?? ((x, y) => default(TResult)))(source, arg);
        }

        public static Action Match<T>(this T source, IActionPattern<Func<T, bool>, Action<T>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<T, bool>, Action<T>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault() ?? ((x) => { }))(default(T));

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return () => x.Value(source);

            return () => (p.GetDefault() ?? ((x) => { }))(source);
        }

        public static Func<TResult> Match<T, TResult>(this T source, IActionPattern<Func<T, bool>, Func<T, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<T, bool>, Func<T, TResult>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return () => (p.GetCatchNull() ?? p.GetDefault() ?? (x => default(TResult)))(default(T));

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return () => x.Value(source);

            return () => (p.GetDefault() ?? (x => default(TResult)))(source);
        }

        public static Action<TSecondary> Match<TPrimary, TSecondary>(this TPrimary source, IActionPattern<Func<TPrimary, bool>, Action<TPrimary, TSecondary>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<TPrimary, bool>, Action<TPrimary, TSecondary>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return arg => (p.GetCatchNull() ?? p.GetDefault() ?? ((x, y) => { }))(default(TPrimary), arg);

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return arg => x.Value(source, arg);

            return arg => (p.GetDefault() ?? ((x, y) => { }))(source, arg);
        }

        public static Func<TSecondary, TResult> Match<TPrimary, TSecondary, TResult>(this TPrimary source, IActionPattern<Func<TPrimary, bool>, Func<TPrimary, TSecondary, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<TPrimary, bool>, Func<TPrimary, TSecondary, TResult>>;
            if (p == null)
                throw new Exception();

            if (Object.Equals(source, null))
                return arg => (p.GetCatchNull() ?? p.GetDefault() ?? ((x, y) => default(TResult)))(default(TPrimary), arg);

            foreach (var x in p.GetPatterns())
                if (x.Key(source))
                    return arg => x.Value(source, arg);

            return arg => (p.GetDefault() ?? ((x, y) => default(TResult)))(source, arg);
        }

        public static Action<TSecondary> Match<TPrimary, TSecondary>(this TPrimary source, IActionPattern<Func<TPrimary, TSecondary, bool>, Action<TPrimary, TSecondary>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<TPrimary, TSecondary, bool>, Action<TPrimary, TSecondary>>;
            if (p == null)
                throw new Exception();

            return secondary =>
            {
                if (Object.Equals(source, null) || Object.Equals(secondary, null))
                    (p.GetCatchNull() ?? p.GetDefault() ?? ((x, y) => { }))(default(TPrimary), default(TSecondary));

                foreach (var x in p.GetPatterns())
                    if (x.Key(source, secondary))
                    {
                        x.Value(source, secondary);
                        return;
                    }

                (p.GetDefault() ?? ((x, y) => { }))(source, secondary);
            };
        }

        public static Func<TSecondary, TResult> Match<TPrimary, TSecondary, TResult>(this TPrimary source, IActionPattern<Func<TPrimary, TSecondary, bool>, Func<TPrimary, TSecondary, TResult>> pattern)
        {
            var p = pattern as IActionPatternGetter<Func<TPrimary, TSecondary, bool>, Func<TPrimary, TSecondary, TResult>>;
            if (p == null)
                throw new Exception();

            return secondary =>
            {
                if (Object.Equals(source, null) || Object.Equals(secondary, null))
                    return (p.GetCatchNull() ?? p.GetDefault() ?? ((x, y) => default(TResult)))(default(TPrimary), default(TSecondary));

                foreach (var x in p.GetPatterns())
                    if (x.Key(source, secondary))
                    {
                        return x.Value(source, secondary);
                    }

                return (p.GetDefault() ?? ((x, y) => default(TResult)))(source, secondary);
            };
        }
    }
}
