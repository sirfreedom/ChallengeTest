
namespace WinFormDisegnPattern.InyeccionDeDependencias2
{
    public class SqlDatabase : IPersister
    {

        public string Save(Shopping oShoping) 
        {
            //Aca deberiamos guardar el shopping
            return "Se guarda en la SQL Server";
        }



    }
}
