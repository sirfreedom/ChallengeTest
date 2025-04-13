using System;
using System.Threading;
using System.Threading.Tasks;

namespace WinFormDisegnPattern.Thread2
{
    public class BreakFastThread
    {

        private BreakFastThread() { }

        public static BreakFastThread getInstance {get { return new BreakFastThread(); } }

        #region Sin Threading

        public string VoilWater() 
        {
            Console.WriteLine();
            Console.Write("*Calentar Agua");
            Console.WriteLine();
            Thread.Sleep(10000);
            Console.Write("*S-Agua Caliente");
            Console.WriteLine("");
            return string.Empty;
        }

        public string PutCoffeIntoTheCup() 
        {
            Console.WriteLine();
            Console.Write("*Poniendo cafe enla taza");
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.Write("*S-Puse Cafe");
            Console.WriteLine("");
            return string.Empty;
        }

        public string PutSugarIntoTheCup() 
        {
            Console.WriteLine();
            Console.Write("*Pongo azucar en la taza");
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.Write("*S-Puse Azucar");
            Console.WriteLine("");
            return string.Empty;
        }

        public string HeatMilk() 
        {
            Console.WriteLine();
            Console.Write("*Caliento la leche");
            Console.WriteLine("");
            Thread.Sleep(9000);
            Console.Write("*S-Leche Caliente");
            Console.WriteLine("");
            return string.Empty;
        }

        public string DrinkCoffeWithMilk() 
        {
            Console.WriteLine();
            Console.Write("*Bebo el cafe con leche");
            Console.WriteLine();
            Thread.Sleep(5000);
            Console.Write("*S-Desayune");
            Console.WriteLine("");
            return string.Empty;
        }

        #endregion

        #region Con Threading

        public async Task<string> VoilWater_Async()
        {
            Console.WriteLine();
            Console.Write("-A-Calentar Agua");
            Console.WriteLine();
            await Task.Delay(17000);
            Console.Write("-A-Agua Caliente");
            Console.WriteLine("");
            return "Agua Caliente";
        }

        public async Task<string> PutCoffeIntoTheCup_Async()
        {
            Console.WriteLine();
            Console.Write("-A-Poniendo cafe enla taza");
            Console.WriteLine();
            await Task.Delay(2000);
            Console.Write("-A-Puse Cafe");
            Console.WriteLine("");
            return string.Empty;
        }

        public async Task<string> PutSugarIntoTheCup_Async()
        {
            Console.WriteLine();
            Console.Write("-A-Pongo azucar en la taza");
            Console.WriteLine();
            await Task.Delay(2000);
            Console.Write("-A-Puse Azucar");
            Console.WriteLine("");
            return string.Empty;
        }

        public async Task<string> HeatMilk_Async()
        {
            Console.WriteLine();
            Console.Write("-A-Caliento la leche");
            Console.WriteLine();
            await Task.Delay(9000);
            Console.Write("-A-Listo Leche Caliente");
            Console.WriteLine("");
            return "Leche Caliente";
        }

        public async Task<string> DrinkCoffeWithMilk_Async()
        {
            Console.WriteLine();
            Console.Write("-A-Empezando a tomar el cafe con leche");
            Console.WriteLine();
            await Task.Delay(10000);
            Console.Write("-A-Desayune");
            Console.WriteLine("");
            return "BeboCafe";
        }


        #endregion

        #region Threading Orden

        public async Task AsyncronicMetodo(string Nombre)
        {
            await AsyncronicMetodo1(Nombre);
            await AsyncronicMetodo2(Nombre);
            await AsyncronicMetodo3(Nombre);
            await AsyncronicMetodo4(Nombre);
        }

        public async Task AsyncronicMetodo1(string Nombre) 
        {
            Console.WriteLine();
            Console.Write("Metodo 1 - Ini ");
            Console.Write(Nombre);
            await Task.Delay(10000);
            Console.Write("Metodo 1 - Fin ");
            Console.Write(Nombre);
            Console.WriteLine("");
        }

        public async Task AsyncronicMetodo2(string Nombre)
        {
            Console.WriteLine();
            Console.Write("Metodo 2 - Ini ");
            Console.Write(Nombre);
            await Task.Delay(6000);
            Console.Write("Metodo 2 - Fin ");
            Console.Write(Nombre);
            Console.WriteLine("");
        }

        public async Task AsyncronicMetodo3(string Nombre)
        {
            Console.WriteLine();
            Console.Write("Metodo 3 - Ini ");
            Console.Write(Nombre);
            await Task.Delay(7000);
            Console.Write("Metodo 3 - Fin ");
            Console.Write(Nombre);
            Console.WriteLine("");
        }

        public async Task AsyncronicMetodo4(string Nombre)
        {
            Console.WriteLine();
            Console.Write("Metodo 4 - Ini ");
            Console.Write(Nombre);
            await Task.Delay(8000);
            Console.Write("Metodo 4 - Fin ");
            Console.Write(Nombre);
            Console.WriteLine("");
        }

        #endregion 



    }
}
