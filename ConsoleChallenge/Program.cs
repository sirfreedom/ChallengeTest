using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleChallenge
{
    class Program
    {





        private static async Task Test_CountItemsWithAgeGreaterThanEqual() 
        {
            string url = "https://coderbyte.com/api/challenges/json/age-counting";
            string response = await Helper.getInstance.GetResponseAsync(url);
            int count = Challenge.getInstance.CountItemsWithAgeGreaterThanEqual(response, 50);
            Console.WriteLine(count);
        }

        private static void Test_ReadComplexJson() 
        {
            //string sPath = @"..\JsonParse\4.json";
            //string sJson;
            //sJson = File.ReadAllText(sPath);
            //Challenge.getInstance.ReadComplexJson(sJson);
        }

        private static void Test_FindMaximNumber()
        {
            Console.WriteLine(Challenge.getInstance.FindMaximumPossibleValue(268));
            Console.WriteLine(Challenge.getInstance.FindMaximumPossibleValue(670));
            Console.WriteLine(Challenge.getInstance.FindMaximumPossibleValue(0));
            Console.WriteLine(Challenge.getInstance.FindMaximumPossibleValue(-999));
        }

        private static void Test_FindFirstSecuenceWhosLenghtEqualOne() 
        {
            int[] lBinary = {0,0,1,1,1,0,0,0,1,1,1,1,1};
            Console.WriteLine(Challenge.getInstance.FindFirstSecuenceWhosLenghtEqualOne(lBinary));
            Console.ReadLine();
        }

        private static void Test_FindTotalImbalance() 
        {
            long result = 0;
            var data = new[]
            {
                4, 1, 3, 2
            };
            result = Challenge.getInstance.FindTotalImbalance(data);
            Console.WriteLine(result);
            Console.ReadLine();
        }


        private static void Test_WordParser() 
        {
            string output = Challenge.getInstance.WordParser("Creativity is thinking-up new things. Innovation is doing new things!");
            Console.WriteLine(output);
        }

        private static void Test_CalPoints() 
        {
            string[] ops = { "5", "2", "C", "D", "+" };
            Console.WriteLine(Challenge.getInstance.CalPoints(ops));
        }

        private static void Test_StringChallenge() 
        {
            Console.WriteLine(Challenge.getInstance.StringChallenge("coderbyte"));
        }

        private static void Test_Ordenar() 
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> list = new List<int>(array);
            Console.WriteLine(String.Join(",", list));
            int[] arrayRet = Challenge.getInstance.ordenar(array1, 3);
            Console.WriteLine("Final\n");
            foreach (int i in arrayRet)
            {
                Console.Write(i);
            }
        }

        private static void Test_FizzBuzz() 
        {
            Challenge.getInstance.FizzBuzz(15);
        }

        private static void Test_SimplificarFraccion() 
        {
            Console.WriteLine(Challenge.getInstance.SimplificarFraccion("100/400"));
            Console.WriteLine(Challenge.getInstance.SimplificarFraccion("20/5"));
            Console.WriteLine(Challenge.getInstance.SimplificarFraccion("4/6"));
            Console.WriteLine(Challenge.getInstance.SimplificarFraccion("10/11"));
        }

        private static void Test_Fibonacci() 
        {
            Console.WriteLine(Challenge.getInstance.Fibonacci());
        }

        private static void Test_FirstUniqueProduct() 
        {
            Console.WriteLine(Challenge.getInstance.FirstUniqueProduct(new string[] { "Apple", "Computer", "Apple", "Bag" }));
        }

        private static void Test_ValidName() 
        {
            Console.WriteLine(Challenge.getInstance.ValidName("E. Poe"));
            Console.WriteLine(Challenge.getInstance.ValidName("E. Poe")); //➞true
            Console.WriteLine(Challenge.getInstance.ValidName("E. A. Poe")); //➞true
            Console.WriteLine(Challenge.getInstance.ValidName("Edgard A. Poe")); //➞true
            Console.WriteLine(Challenge.getInstance.ValidName("Edgard")); //➞false
            ////deben ser 2 o tres palabras
            Console.WriteLine(Challenge.getInstance.ValidName("e. Poe")); //➞false
            // capitalizacion
            Console.WriteLine(Challenge.getInstance.ValidName("E Poe"));// ➞false
            Console.WriteLine(Challenge.getInstance.ValidName("E. A Poe"));// ➞false
            //falta el punto detrás de la inicial

            Console.WriteLine(Challenge.getInstance.ValidName("E. Allan Poe")); //➞false
            //// no es válido: inicial como primer nombre y palabra como segundo
            Console.WriteLine(Challenge.getInstance.ValidName("E. Allan P.")); //➞false
            //// Apellido como inicial
            Console.WriteLine(Challenge.getInstance.ValidName("Edg. Allan Poe")); //➞false
            //// Las palabras no pueden finalizar con punto (solo iniciales)
            ///
        }

        private static void Test_getHeaviestPackage() 
        {
            int[] array = { 2, 9, 10, 3, 7 };
            long result = 0;
            List<int> input = new List<int>(array);
            result = Challenge.getInstance.getHeaviestPackage(input);
            Console.WriteLine("the weight of heaviest package is " + result);
        }



        static void Main(string[] args)
        {
            //await Test_CountItemsWithAgeGreaterThanEqual();
            //Test_ReadComplexJson();
            //Test_FindMaximNumber();
            //Test_FindTotalImbalance();
            //Test_WordParser();
            //Test_CalPoints();
            //Test_StringChallenge();
            //Test_Ordenar();
            //Test_FizzBuzz();
            //Test_Fibonacci();
            //Test_FirstUniqueProduct();
            //Test_ValidName();
            //Test_SimplificarFraccion();
            //Test_FindFirstSecuenceWhosLenghtEqualOne();
            //Test_getHeaviestPackage();
        }






    }
}
