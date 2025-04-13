

using System;

namespace WinFormDisegnPattern.ChainOfResponsibility
{
    public class ConcreteHandler2 : Handler
    {

        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
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
