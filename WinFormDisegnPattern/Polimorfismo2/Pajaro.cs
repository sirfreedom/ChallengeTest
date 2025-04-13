

namespace WinFormDisegnPattern.Polimorfismo2
{
    public class Pajaro : Animal, IRuidoAnimal
    {
        private const string _Nombre = "Pajaro";

        public override string NombreAnimal
        {
            get { return _Nombre; }
        }


        public string HacerRuido()
        {
            return "Piu Piu Piu";
        }



    }
}
