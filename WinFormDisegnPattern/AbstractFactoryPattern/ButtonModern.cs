using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class ButtonModern : Button, IButton
    {
        Color _BackColor = Color.LightCyan;

        public override Color BackColor
        {
            get { return _BackColor; }
            set { _BackColor = value; }
        }

        public string PruebaMethodButton()
        {
            return "Button Modern";
        }
    }
}
