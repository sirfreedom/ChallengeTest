

namespace WinFormDisegnPattern.SegregacionDeInterfaces
{
    class Conejo : Animal, IRunner
    {
        public string Correr()
        {
            return "Correr";
        }

        public string Saltar()
        {
            return "Saltar";
        }

        public string Trepar()
        {
            return "Trepar";
        }
    }
}
