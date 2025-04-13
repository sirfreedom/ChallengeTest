


namespace WinFormDisegnPattern.FactoryMethodPattern
{
    public class Barco : MediosDeTrasporte, IMediosDeTrasporte
    {

  

        public override string Prender()
        {
            return "Prender Barco";
        }

        public override string Apagar()
        {
            return "Apagar Barco";   
        }


    }
}
