using System;
using System.Collections.Generic;

namespace WinFormDisegnPattern.Thread1
{

    public class TestHelper
    {


        public static void WriteToConsole(string s)
        {
            Console.Out.WriteLine(s);
        }

        public static List<string> WordHardToDo(string Parameter)
        {
            List<string> lTest = new List<string>();

            for (int i = 0; i < 1000; i++) 
            {
                lTest.Add(Parameter + i.ToString());
            }

            System.Threading.Thread.Sleep(60000);
            return lTest;
        }

        public static void WordHardToDo(object Parameter)
        {
            List<string> lTest = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                lTest.Add(i.ToString());
            }

            System.Threading.Thread.Sleep(60000);
        }

        public static double CalcAverage(int[] numbers)
        {
            var average = 0.0;

            if (numbers == null || numbers.Length == 0)
            {
                return 0.0;
            }

            foreach (var number in numbers)
            {
                average += number;
            }
            average /= numbers.Length;

            System.Threading.Thread.Sleep(60000);

            return average;
        }




    }
}
