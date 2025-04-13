

namespace WinFormDisegnPattern.FactoryMethod
{
    public class Sum : FactoryMethodBase, IOperation
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
