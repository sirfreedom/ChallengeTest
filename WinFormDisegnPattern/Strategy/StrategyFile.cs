using System;
using System.Data;


namespace WinFormDisegnPattern.Strategy
{
    public class StrategyFile : IStrategy
    {



        public string Save(DataSet ds)
        {
            return "Save File";
        }
    }
}
