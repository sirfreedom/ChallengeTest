
namespace WinFormDisegnPattern.InyeccionDeDepencias1
{
    public class Store
    {

        private readonly IPaymentProcess _PaymentProcess;

        //inyectamos la implementacion del metodo de pago en el constructor
        public Store(IPaymentProcess paymentProcess) 
        {
            _PaymentProcess = paymentProcess;
        }

        //Pagar
        public string Purchase() 
        {
            return _PaymentProcess.Pay();
        }




    }
}
