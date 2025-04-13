

namespace WinFormDisegnPattern.Builder
{
    public class House : IHouse
    {
        private Product _product = new Product();
        
        public void CreateArbol()
        {
            _product.Add("Creamos un Arbol");
        }

        public void CreateCerco()
        {
            _product.Add("Creamos un Cerco");
        }

        public void CreateParque()
        {
            _product.Add("Creamos un Parque");
        }

        public void CreatePicina()
        {
            _product.Add("Creamos una Picina");
        }

        public void Reset() 
        {
            _product = new Product();
        }

        public override string ToString()
        {
            return _product.ListParts();
        }

    }
}
