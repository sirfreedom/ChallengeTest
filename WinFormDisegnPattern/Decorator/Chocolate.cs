
namespace WinFormDisegnPattern.Decorator
{
    public class Chocolate : BebidaDecorator
    {
        Bebida _Bebida;
        const double PRICE = 4;
        const string DESCRIPTION = " Chocolate ";

        public Chocolate(Bebida bebida)
        {
            _Bebida = bebida;
        }

        public override string Description 
        {
            get 
            { 
                return base.Description + _Bebida.Description +  DESCRIPTION; 
            }
        }

        public override double Price 
        { 
            get 
            { 
                return base.Price + _Bebida.Price + PRICE; 
            }
        }



    }
}
