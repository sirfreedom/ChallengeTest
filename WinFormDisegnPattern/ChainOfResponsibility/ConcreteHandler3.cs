using System;


namespace WinFormDisegnPattern.ChainOfResponsibility
{
    public class ConcreteHandler3 : Handler
    {


        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"{this.GetType().Name} maneja la solicitud {request}");
            }
            if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }

    }
}
