

namespace WinFormDisegnPattern.FactoryMethod
{
    public class Subtract : FactoryMethodBase, IOperation
    {

        public int Calculate(int a, int b)
        {
            return a - b;
        }

    }

}
