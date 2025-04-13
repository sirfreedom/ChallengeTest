

namespace WinFormDisegnPattern.ChainOfResponsibility
{

    // Clase base abstracta para el manejo de la solicitud
    public abstract class Handler
    {

        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);

    }
}
