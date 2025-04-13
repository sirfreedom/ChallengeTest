using System;
using System.Text;

namespace WinFormDisegnPattern.Command
{

    /*
    En el contexto del patrón Command, el *receptor* es la clase que contiene 
    la lógica real para realizar las operaciones solicitadas. Es decir, cuando un comando se ejecuta, 
    este invoca métodos en el receptor para llevar a cabo la acción deseada.

    */

    public class EditorTexto
    {

        private StringBuilder _texto = new StringBuilder();


        // Logica de Agregar texto
        public void AgregarTexto(string texto)
        {
            _texto.Append(texto);
            Console.WriteLine($"Texto agregado: {texto}");
        }

        //Logica de Eliminar texto
        public void EliminarTexto(int longitud)
        {
            if (longitud > _texto.Length)
                longitud = _texto.Length;

            string textoEliminado = _texto.ToString().Substring(_texto.Length - longitud);
            _texto.Remove(_texto.Length - longitud, longitud);
            Console.WriteLine($"Texto eliminado: {textoEliminado}");
        }



    }
}
