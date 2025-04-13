using System;

namespace PatronAdapter
{
    public class MotorElectrico 
    {

        public void Activar() 
        {
            Console.WriteLine("Activar Motor electrico");
        }

        public void Conectar() 
        {
            Console.WriteLine("Conectar motor electrico");
        }

        public void EnchufarCarga()
        {
            Console.WriteLine("Enchufar Carga Motor electrico");
        }

        public void Desconectar() 
        {
            Console.WriteLine("Desconectar motor electrico");
        }

        public void Parar() {
            Console.WriteLine("Para Motor electrico");
        }

        public void Mover() {
            Console.WriteLine("Mover motor electrico");
        }


    }
}
