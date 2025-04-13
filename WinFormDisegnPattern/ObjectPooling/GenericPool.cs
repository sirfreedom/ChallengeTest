using System;
using System.Collections.Generic;


namespace WinFormDisegnPattern.ObjectPooling
{
    public class GenericPool<T> where T : class, new()
    {
        public int inUse { get; set; }
        private Queue<T> pool;
        private int maxSize { get; set; }


        public GenericPool(int maxSize)
        {
            pool = new Queue<T>();
            inUse = 0;
            this.maxSize = maxSize;
        }

        public void AddToPool(T o)
        {
            pool.Enqueue(o);
        }

        public T GetNext()
        {
            T obj;
            //Obtener nuevo desde la pool
            if (pool.Count > 0)
            {
                obj = pool.Dequeue();
                inUse++;
                return obj;
            }
            //Generar nuevo 
            //si no se ha llegado al límite maxSize
            if (pool.Count == 0 && inUse < maxSize)
            {
                obj = new T();
                inUse++;
                return obj;
            }
            return null;
        }

        public int Recycle(T o)
        {
            pool.Enqueue(o);
            inUse--;
            return inUse;
        }

        public int GetAvailableCount() => pool.Count;
        public int GetTotalPopulation() => pool.Count + inUse;


    }
}
