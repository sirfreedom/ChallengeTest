using System;
using System.Collections.Generic;

namespace WinFormDisegnPattern.Observer1
{
    public class WeatherStation : ISubject
    {

        private List<IObserver> lObserver = new List<IObserver>();

        private float _Temperature = 0;

        public float Temperature 
        {
            get { return _Temperature;  }
            set 
            {
                _Temperature = value;
                Notify();
            }
        }


        public void Attach(IObserver observer)
        {
            lObserver.Add(observer);
            Console.Write("Se Agrega un Observador");
        }

        public void Notify()
        {
            foreach (IObserver o in lObserver) 
            {
                Console.Write("Notificando");
                o.Update(this);
            }
        }


        




    }
}
