using System.Windows.Forms;

namespace WinFormDisegnPattern.AbstractFactoryPattern
{
    public class OlderFactory : IFactoryGUI
    {
        public IButton CreateButton()
        {
            return new ButtonOlder();
        }

        public ITextBox CreateTextBox()
        {
            return new TextBoxOlder();
        }


    }
}
