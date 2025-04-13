using System;


namespace WinFormDisegnPattern.Command
{
    public class Calculadora
    {

        public int Resultado { get; private set; }

        public void Sumar(int valor)
        {
            Resultado += valor;
            Console.WriteLine($"Resultado actual: {Resultado}");
        }

        public void Restar(int valor)
        {
            Resultado -= valor;
            Console.WriteLine($"Resultado actual: {Resultado}");
        }


    }
}
