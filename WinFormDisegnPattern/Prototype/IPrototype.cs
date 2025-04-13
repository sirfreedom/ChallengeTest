

namespace WinFormDisegnPattern.Prototype
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}
