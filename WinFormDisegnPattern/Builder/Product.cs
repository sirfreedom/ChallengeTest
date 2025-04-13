using System.Text;

namespace WinFormDisegnPattern.Builder
{
    public class Product
    {

        private StringBuilder _parts = new StringBuilder();

        public void Add(string part)
        {
            this._parts.AppendLine(part);
        }

        public string ListParts()
        {
            return _parts.ToString();
        }
    }
}
