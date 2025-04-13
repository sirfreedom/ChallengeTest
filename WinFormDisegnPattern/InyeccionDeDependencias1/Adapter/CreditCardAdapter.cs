

namespace WinFormDisegnPattern.InyeccionDeDepencias1
{
    public class CreditCardAdapter : IPaymentProcess
    {
        //Instancio para usar la supuesta API, esto si estaria acoplado, pero seria una API.
        private CreditCardApi _CreditCardApi = new CreditCardApi();


        public string Pay()
        {
            return _CreditCardApi.PayWithCreditCard();
        }


    }
}
