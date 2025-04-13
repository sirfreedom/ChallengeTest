using System;


namespace WinFormDisegnPattern.Command
{

    /*

     Comandos*: Cada comando encapsula una acción que se puede ejecutar sobre el receptor, 
     permitiendo separarlo de la lógica del invocador.

     En este patrón, los "comandos" son objetos que representan una acción a realizar. Cada comando tiene un método para ejecutar la acción correspondiente y, a menudo, otro para deshacerla. Esto permite separarte de la lógica de ejecución y tener más flexibilidad.

     Funciona como un "pasa manos" porque permite que un objeto (el invocador) pase la responsabilidad de ejecutar acciones
     a otros objetos (los comandos). Esto hace que el invocador no tenga que conocer los detalles sobre cómo se ejecuta 
     una acción específica; sólo necesita saber qué comando ejecutar.

     */


    public class EliminarTextoCommand : ICommand
    {

        private EditorTexto _editor;
        private int _longitud;

        public EliminarTextoCommand(EditorTexto editor, int longitud)
        {
            _editor = editor;
            _longitud = longitud;
        }

        public void Execute()
        {
            _editor.EliminarTexto(_longitud);
        }


    }
}
