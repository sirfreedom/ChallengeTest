using System;
using System.Text;

namespace WinFormDisegnPattern.FlyWeight
{
    public class UnsharedConcreteFlyweight : Flyweight
    {

        public override string Operation(int extrinsicstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UnsharedConcreteFlyweight: ");
            sb.Append(extrinsicstate);
            return sb.ToString();
        }


    }
}
