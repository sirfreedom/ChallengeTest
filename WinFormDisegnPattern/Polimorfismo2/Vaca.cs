
namespace WinFormDisegnPattern.Polimorfismo2
{
    public class Vaca : Animal, IRuidoAnimal
    {
        private const string _Nombre = "Vaca";

        public override string NombreAnimal
        {
            get { return _Nombre; }
        }

        public string HacerRuido()
        {
            return "Mu Mu Mu";
        }
    }
}
