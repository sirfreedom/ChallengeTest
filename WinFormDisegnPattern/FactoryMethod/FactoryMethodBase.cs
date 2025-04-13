using System;

namespace WinFormDisegnPattern.FactoryMethod
{
    public abstract class FactoryMethodBase
    {


        public string Name
        {
            get
            {
                Type t = this.GetType();
                return t.Name;
            }
        }



    }
}
