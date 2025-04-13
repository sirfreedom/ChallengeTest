using System;

namespace WinFormDisegnPattern.Singleton
{
    public class SingletonPattern
    {

        private static SingletonPattern _instance = null;
        private static object syncRoot = new Object();

        public static SingletonPattern Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot) //Evitamos que ingresen dos procesos consecutivos y concurrentes en el mismo momento.. no se puede importa al mismo tiempo de dos lados.
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonPattern();
                        }
                    }
                }
                return _instance;
            }
        }

        private SingletonPattern() { }

        public string ReadTextFile()
        {
            return "One Instance";
        }



    }
}
