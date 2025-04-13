

namespace WinFormDisegnPattern.RepositoryPattern
{
    public class Producto : BaseEntity 
    {

        public string Descripcion { get; set; }
        public decimal Price { get; set; }
        public int IdTipo { get; set; }

    }
}
