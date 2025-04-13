

namespace WinFormDisegnPattern.Decorator
{
    public class Cafe : Bebida
    {

        public override double Price
        {
            get { return 10; }
        }

        public override string Description 
        { 
            get { return "Cafe solo"; }
        } 

    }
}
