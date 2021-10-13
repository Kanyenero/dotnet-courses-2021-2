using System;


namespace Task3
{
    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
    }

    public interface IIndexable
    {
        double this[int index] { get; }
    }

    public interface IIndexableSeries : ISeries, IIndexable
    {
    }
}
