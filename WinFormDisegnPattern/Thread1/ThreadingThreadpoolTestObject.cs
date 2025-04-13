using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormDisegnPattern.Thread1
{
    public class ThreadingThreadpoolTestObject
    {
        private readonly object lockObject = new object();
        public int NumberOfCalls;

        public void Call()
        {
            lock (lockObject)
            {
                NumberOfCalls++;
            }
        }
    }
}
