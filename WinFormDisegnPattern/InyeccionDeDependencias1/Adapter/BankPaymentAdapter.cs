
namespace WinFormDisegnPattern.InyeccionDeDepencias1
{
    public class BankPaymentAdapter : IPaymentProcess
    {
        //Instancio para usar la supuesta API, esto si estaria acoplado, pero seria una API.
        private BankApi _MyBankApi = new BankApi();

        public string Pay() 
        {
            return _MyBankApi.PayWithBank();
        }


    }
}
