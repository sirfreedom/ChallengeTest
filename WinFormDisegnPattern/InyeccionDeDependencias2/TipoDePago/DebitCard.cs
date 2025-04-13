

namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class DebitCard : IPayment
    {

        public string Pay(Shopping shoping)
        {
            return "Pago con Debit Card";
        }
    }
}
