﻿namespace PokerHandShowdownSolver.Conversion
{
    public interface IConverter<T>
    {
        string ToString(T value);

        T FromString(string str);
    }
}