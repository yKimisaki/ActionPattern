using System;

namespace Tonari.ActionPattern
{
    public static class SwitchPattern
    {
        public static ISwitchPattern<T> Switch<T>(T value)
        {
            return new SwitchPatternCore<T>(value);
        }

        private class BreakedPattern<T> : ISwitchPattern<T>
        {
            public static readonly ISwitchPattern<T> ReturnValue = new BreakedPattern<T>();

            public ISwitchPattern<T> Case(T value, Action<T> action)
            {
                return ReturnValue;
            }

            public ISwitchPattern<T> Case(Func<T, bool> value, Action<T> action)
            {
                return ReturnValue;
            }

            public ISwitchPattern<T> Case<TTargetType>(Action<TTargetType> action)
            {
                return ReturnValue;
            }

            public ISwitchPattern<T> Case<TTargetType>(TTargetType value, Action<TTargetType> action)
            {
                return ReturnValue;
            }

            public ISwitchPattern<T> Case<TTargetType>(Func<TTargetType, bool> predicate, Action<TTargetType> action)
            {
                return ReturnValue;
            }

            public void Default(Action<T> action)
            {
            }
        }

        private class SwitchPatternCore<T> : ISwitchPattern<T>
        {
            private readonly T _value;

            public SwitchPatternCore(T value)
            {
                _value = value;
            }

            public ISwitchPattern<T> Case(T value, Action<T> action)
            {
                if (value.Equals(_value))
                {
                    action(_value);
                    return BreakedPattern<T>.ReturnValue;
                }

                return this;
            }

            public ISwitchPattern<T> Case(Func<T, bool> predicate, Action<T> action)
            {
                if (predicate(_value))
                {
                    action(_value);
                    return BreakedPattern<T>.ReturnValue;
                }

                return this;
            }

            public ISwitchPattern<T> Case<TTargetType>(Action<TTargetType> action)
            {
                var a = action as Action<T>;
                if (a == null)
                {
                    return this;
                }

                a(_value);
                return BreakedPattern<T>.ReturnValue;
            }

            public ISwitchPattern<T> Case<TTargetType>(TTargetType value, Action<TTargetType> action)
            {
                var a = action as Action<T>;
                if (a == null)
                {
                    return this;
                }

                if (value.Equals(_value))
                {
                    a(_value);
                    return BreakedPattern<T>.ReturnValue;
                }

                return this;
            }

            public ISwitchPattern<T> Case<TTargetType>(Func<TTargetType, bool> predicate, Action<TTargetType> action)
            {
                var p = predicate as Func<T, bool>;
                var a = action as Action<T>;
                if (p == null || a == null)
                {
                    return this;
                }

                if (p(_value))
                {
                    a(_value);
                    return BreakedPattern<T>.ReturnValue;
                }

                return this;
            }

            public void Default(Action<T> action)
            {
                action(_value);
            }
        }
    }

    public interface ISwitchPattern<T>
    {
        ISwitchPattern<T> Case(T value, Action<T> action);
        ISwitchPattern<T> Case(Func<T, bool> value, Action<T> action);
        ISwitchPattern<T> Case<TTargetType>(Action<TTargetType> action);
        ISwitchPattern<T> Case<TTargetType>(TTargetType value, Action<TTargetType> action);
        ISwitchPattern<T> Case<TTargetType>(Func<TTargetType, bool> predicate, Action<TTargetType> action);
        void Default(Action<T> action);
    }
}
