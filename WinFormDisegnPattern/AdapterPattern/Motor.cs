using System;


namespace PatronAdapter
{
    public class Motor : IMotor
    {
        public virtual void Acelerar()
        {
            Console.WriteLine("Implementacion de Acelerar comun");
        }

        public virtual void Apagar()
        {
            Console.WriteLine("Implementacion de Apagar Comun");
        }

        public virtual void Arrancar()
        {
            Console.WriteLine("Implementacion de Arrancar Comun");
        }

        public virtual void CargarCombustible()
        {
            Console.WriteLine("Implementacion de Cargar Combustible Comun");
        }
    }
}
