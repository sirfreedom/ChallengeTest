using System;
using System.Data;


namespace WinFormDisegnPattern.Strategy
{
    public class StrategyXml : IStrategy
    {
        public string Save(DataSet ds)
        {
            return "Save Xml";
        }
    }
}
