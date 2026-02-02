using System;

public interface IReadOnlyReactiveVariable<T>
{
    T Value { get; }
    event Action<T, T> Changed;
}