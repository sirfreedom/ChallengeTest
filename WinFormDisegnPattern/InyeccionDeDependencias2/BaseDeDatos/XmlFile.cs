

namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class XmlFile : IPersister
    {

        public string Save(Shopping shopping)
        {
            return "Se Guarda en XML";    
        }
    }
}
