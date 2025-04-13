

namespace WinFormDisegnPattern.Observer1
{
    public interface ISubject
    {

        void Attach(IObserver observer);

        void Notify();

    }
}
