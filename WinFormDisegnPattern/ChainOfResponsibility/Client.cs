

namespace WinFormDisegnPattern.ChainOfResponsibility
{
    public class Client
    {


        public void MakeRequest(int request, Handler handler)
        {
            handler.HandleRequest(request);
        }



    }
}
