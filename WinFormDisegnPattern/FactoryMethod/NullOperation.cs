using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormDisegnPattern.FactoryMethod
{
    public class NullOperation : FactoryMethodBase, IOperation
    {
        public int Calculate(int a, int b)
        {
            return 0;
        }
    }
}
