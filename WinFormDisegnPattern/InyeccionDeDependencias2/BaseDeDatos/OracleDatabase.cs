

namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class OracleDatabase : IPersister
    {

        public string Save(Shopping shopping)
        {
            return "Se Guarda en oracle.";
        }
    }
}
