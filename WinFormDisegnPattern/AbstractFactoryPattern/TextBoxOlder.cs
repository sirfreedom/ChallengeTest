using System.Drawing;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class TextBoxOlder : TextBox, ITextBox
    {
        Color _BackColor = Color.Gray;
        
        public override Color BackColor 
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        public string PruebaProperty 
        {
            get { return base.Text + " Older"; }
        }

        public string PruebaMethodTextBox()
        {
            return "TextBox Older";
        }






    }
}
