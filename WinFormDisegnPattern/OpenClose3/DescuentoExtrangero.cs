

namespace WinFormDisegnPattern.OpenClose
{
    public class DescuentoExtrangero : Descuento
    {


        public override double GetDiscount(double amount)
        {
            return base.GetDiscount(amount) - 8;
        }

    }
}
