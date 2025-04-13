using System;

namespace WinFormDisegnPattern.ChainOfResponsibility
{
    public class ConcreteHandler1 : Handler
    {

        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
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
