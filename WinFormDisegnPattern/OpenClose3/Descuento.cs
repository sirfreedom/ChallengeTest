


namespace WinFormDisegnPattern.OpenClose
{
    public abstract class Descuento
    {

        public virtual double GetDiscount(double amount)
        {
            return amount - 1;
        }



    }
}
