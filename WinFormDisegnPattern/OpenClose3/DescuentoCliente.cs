

namespace WinFormDisegnPattern.OpenClose
{
    public class DescuentoCliente : Descuento
    {

        public override double GetDiscount(double amount)
        {
            return base.GetDiscount(amount) - 5;
        }



    }
}
