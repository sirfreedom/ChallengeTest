
namespace WinFormDisegnPattern.InyeccionDeDepencias1
{
    public class PayPalAdapter : IPaymentProcess
    {
        //Instancio para usar la supuesta API, esto si estaria acoplado, pero seria una API.
        private PayPalApi _PayPalApi = new PayPalApi();


        public string Pay()
        {
            return _PayPalApi.PayToPayPal();
        }







    }
}
