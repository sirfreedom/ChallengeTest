

namespace WinFormDisegnPattern.StatePattern
{
    public class ContextState
    {
        IState _State = null;

        public ContextState(IState state) 
        {
            _State = state;
        }

        public IState ConfigurarState 
        {
            set { _State = value; }
        }

        public string Request() 
        {
            return _State.Handler();
        }

    }
}
