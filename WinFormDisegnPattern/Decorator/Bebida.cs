

namespace WinFormDisegnPattern.Decorator
{
    public abstract class Bebida
    {

        public virtual double Price
        {
            get { return 0; }
        }
        public virtual string Description 
        {
            get { return string.Empty; } 
        }

    }
}
