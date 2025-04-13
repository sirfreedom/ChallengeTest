

namespace WinFormDisegnPattern.OpenClose
{
    public class DescuentoNoCliente : Descuento
    {

        public override double GetDiscount(double amount)
        {
            return base.GetDiscount(amount) - 0;
        }

    }
}
