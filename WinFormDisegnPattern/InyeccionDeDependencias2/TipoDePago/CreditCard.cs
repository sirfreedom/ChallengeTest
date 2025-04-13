

namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class CreditCard : IPayment
    {

        public string Pay(Shopping shopingBasket) 
        {
            //Aca se realiza el pago con la informacion de la compra 

            return "pago con Credit Card";
        }



    }
}
