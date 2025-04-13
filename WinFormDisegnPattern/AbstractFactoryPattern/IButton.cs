using System.Drawing;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public interface IButton // Implementacion base de la familia
    {

        public Color BackColor { get; set; }
        public string PruebaMethodButton();


    }
}
