using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class TextBoxModern : TextBox, ITextBox
    {
        Color _BackColor = Color.LightCyan; 

        public override Color BackColor 
        {
            get 
            { 
                return _BackColor; 
            
            }
            set { _BackColor = value; } 
        }

        public string PruebaProperty 
        {
            get { return base.Text + " Modern"; }    
        }

        public string PruebaMethodTextBox()
        {
            return "TextBox Modern";
        }
    }
}
