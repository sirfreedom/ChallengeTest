using System;
using System.Data;

namespace WinFormDisegnPattern.Strategy
{
    public class StrategyMemory : IStrategy
    {

        public string Save(DataSet ds)
        {
            return "Save Memory";
        }
    }
}
