using System.Collections;


namespace WinFormDisegnPattern.Iterator1
{
    public abstract class IteratorAggregateBase : IEnumerable
    {

        public abstract IEnumerator GetEnumerator();

    }
}
