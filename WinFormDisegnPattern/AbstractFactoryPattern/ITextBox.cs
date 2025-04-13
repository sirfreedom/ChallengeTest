using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public interface ITextBox
    {

        public Color BackColor { get; set; }

        public string PruebaProperty 
        {
            get;
        }

        public string PruebaMethodTextBox();

    }
}
