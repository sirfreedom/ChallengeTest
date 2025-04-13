using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class ButtonOlder : Button, IButton
    {
        Color _BackColor = Color.DarkBlue;

        public override Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }
        public string PruebaMethodButton()
        {
            return "Button Older";
        }
    }
}
