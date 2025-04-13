

using System.Collections.Generic;
using System.Linq;

namespace WinFormDisegnPattern.FactoryMethod
{
    public class OperationFactory
    {

        string _tipo = string.Empty;

        public OperationFactory(string tipo)
        {
            _tipo = tipo;
        }

        public IOperation CreateInstance()
        {
            IOperation operation;
            List<IOperation> lOperation = new List<IOperation>() { new NullOperation(), new Subtract(), new Sum(), new Multiply(), new Divide() };
            operation = lOperation.SingleOrDefault(x => x.Name == _tipo);
            return operation;
        }

    }
}
