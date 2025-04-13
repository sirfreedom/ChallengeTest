using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public interface IFactoryGUI
    {

        IButton CreateButton();
        ITextBox CreateTextBox();


    }
}
