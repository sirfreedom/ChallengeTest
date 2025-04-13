using System.Text;

namespace WinFormDisegnPattern.FlyWeight
{
    public class ConcreteFlyweight : Flyweight
    {

        public override string Operation(int extrinsicstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ConcreteFlyweight: ");
            sb.Append(extrinsicstate);
            return sb.ToString();
        }



    }
}
