

namespace WinFormDisegnPattern.Liskov
{
    public class Aguila : IAve,IAveVoladora
    {
        public string Comer()
        {
            return "AguilaComer";
        }

        public string Volar()
        {
            return "AguilaVolar";
        }


    }
}
