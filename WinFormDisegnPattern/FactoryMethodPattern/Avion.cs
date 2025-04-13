


namespace WinFormDisegnPattern.FactoryMethodPattern
{
    public class Avion : MediosDeTrasporte, IMediosDeTrasporte
    {

        public override string Apagar()
        {
            return "Apagar Avion";
        }

        public override string Prender()
        {
            return "Prender Avion";
        }


    }
}
