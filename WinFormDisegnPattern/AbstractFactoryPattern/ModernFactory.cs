using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class ModernFactory : IFactoryGUI
    {
        public IButton CreateButton()
        {
            return new ButtonModern(); 
        }

        public ITextBox CreateTextBox()
        {
            return new TextBoxModern();
        }
    }
}
