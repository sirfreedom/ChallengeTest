using System.Data;

namespace WinFormDisegnPattern.Strategy
{
    public class SelectStrategy : IStrategy
    {

        private IStrategy Context;

        public SelectStrategy(IStrategy value) 
        {
            Context = value;
        }

        public string Save(DataSet ds)
        {
            return Context.Save(ds);
        }
    }
}
