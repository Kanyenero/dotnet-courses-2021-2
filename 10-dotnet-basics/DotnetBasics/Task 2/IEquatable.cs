using System.Diagnostics.CodeAnalysis;

namespace System
{
    public interface IEquatable <T>
    {
        bool Equals([AllowNull] T other);
    }
}
