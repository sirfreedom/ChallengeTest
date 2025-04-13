using System.Collections.Generic;

namespace WinFormDisegnPattern.FlyWeight
{
    public class FlyweightFactory
    {

        private Dictionary<string, Flyweight> flyweights { get; set; } = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("1", new ConcreteFlyweight());
            flyweights.Add("2", new ConcreteFlyweight());
            flyweights.Add("3", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }


    }
}
