using System;


namespace WinFormDisegnPattern.FactoryMethod
{
    public class Divide : FactoryMethodBase, IOperation
    {

        public int Calculate(int a, int b)
        {
            try
            {

                return a / b;

            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
