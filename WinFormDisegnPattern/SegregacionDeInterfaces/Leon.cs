

namespace WinFormDisegnPattern.SegregacionDeInterfaces
{
    public class Leon : Animal, IHunter, IRunner
    {
        public string Atacar()
        {
            return "Atacar";
        }

        public string Cazar()
        {
            return "Cazar";
        }

        public string Correr()
        {
            return "Correr";
        }

        public string Roer()
        {
            return "Roer";
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
