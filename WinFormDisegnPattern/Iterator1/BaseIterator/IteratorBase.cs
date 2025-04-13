using System.Collections;

namespace WinFormDisegnPattern.Iterator1
{
    public abstract class IteratorBase : IEnumerator
    {

        object IEnumerator.Current => Current();

        // Retorna la llave 
        public abstract int Key();

        // Retorna el elemento 
        public abstract object Current();

        // mueve un elemento
        public abstract bool MoveNext();

        // revovina los elementos
        public abstract void Reset();

    }

}
