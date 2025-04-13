using System.Collections.Generic;

namespace WinFormDisegnPattern.Command
{
    /*
        Esta clase solo sirve para invocar de forma abstracta los comandos.
    */

    public class Invoker
    {
        private List<ICommand> _comandos = new List<ICommand>();

        public void AddCommand(ICommand comando)
        {
            _comandos.Add(comando);
        }

        public void EjecutarComandos()
        {
            foreach (var comando in _comandos)
            {
                comando.Execute();
            }
        }


    }
}
