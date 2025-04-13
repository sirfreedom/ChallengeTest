

namespace WinFormDisegnPattern.Polimorfismo2
{
    public class Perro : Animal, IRuidoAnimal
    {

        private const string _Nombre = "Perro";

        public override string NombreAnimal
        {
            get { return _Nombre; }
        }


        public string HacerRuido()
        {
            return "Guau Guau Guau";
        }


    }
}
