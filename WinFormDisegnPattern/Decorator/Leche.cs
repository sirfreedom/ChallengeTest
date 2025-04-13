

namespace WinFormDisegnPattern.Decorator
{
    public class Leche : BebidaDecorator
    {
        Bebida _Bebida;

        const double PRICE = 2;
        const string DESCRIPCION = " Leche ";

        public Leche(Bebida bebida) 
        {
            _Bebida = bebida;
        }

        public override double Price 
        {
            get {
                return base.Price + _Bebida.Price  + PRICE;    
            }
        }

        public override string Description 
        {
            get {
                return base.Description + _Bebida.Description + DESCRIPCION;    
            }
        }


    }
}
