
namespace WinFormDisegnPattern.Decorator
{
    public abstract class BebidaDecorator : Bebida
    {
        private Bebida _Bebida;

        public BebidaDecorator() { }

        public BebidaDecorator(Bebida bebida) 
        {
            _Bebida = bebida;
        }

        public override string Description
        {
            get { return base.Description; }
        }

        public override double Price
        {
            get { return base.Price; }
        }


    }
}
