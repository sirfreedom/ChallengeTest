using System.Text;

namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class MyShopCart
    {
        //Spm readonly para que las dependencias sean inmutables
        private readonly IPersister _Persister;
        private readonly IPayment _PaymentMethod;

        //Aca nos da a elegir que tipo de persistencia queremos usar, y que tipo de pago
        //eso nos permite abstraernos de ambas modalidades, tanto sea la forma de guardado, como el tipo de pago.
        public MyShopCart(IPersister persister, IPayment payment) 
        {
            _Persister = persister;
            _PaymentMethod = payment;
        }

        //En el caso de la compra final, esta ACOPLADA, siempre sera un shopping
        //pero tambien podriamos desacoplar la compra utilizando una interface que se abstraiga de que guardamos.
        public string Buy(Shopping oShopping) 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_Persister.Save(oShopping));
            sb.AppendLine(_PaymentMethod.Pay(oShopping));
            return sb.ToString();
        }

    }
}
