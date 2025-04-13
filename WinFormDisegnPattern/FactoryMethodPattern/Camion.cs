

namespace WinFormDisegnPattern.FactoryMethodPattern
{
    public class Camion : MediosDeTrasporte, IMediosDeTrasporte
    {

        public override string Prender()
        {
            return "Prender Camion";
        }

        public override string Apagar()
        {
            return "Apagar Camion";
        }

    }
}
