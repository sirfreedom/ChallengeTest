using ConsoleChallenge.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;


namespace ConsoleChallenge
{
    public class Challenge
    {

        private Challenge() { }

        public static Challenge getInstance
        {
            get
            {
                return new Challenge();
            } 
        }

        Dictionary<char, string> morseAlphabet = new Dictionary<char, string>
        {
            {'a', ".-"}, {'b', "-..."}, {'c', "-.-."}, {'d', "-.."}, {'e', "."},
            {'f', "..-."}, {'g', "--."}, {'h', "...."}, {'i', ".."}, {'j', ".---"},
            {'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."}, {'o', "---"},
            {'p', ".--."}, {'q', "--.-"}, {'r', ".-."}, {'s', "..."}, {'t', "-"},
            {'u', "..-"}, {'v', "...-"}, {'w', ".--"}, {'x', "-..-"}, {'y', "-.--"},
            {'z', "--.."}
        };


        public string WordToMorse(string word)
        {
            string sWord = string.Empty;
            StringBuilder sbMorseWord = new StringBuilder();
            try
            {
                sWord = word.ToLower();
                foreach (char letter in sWord.ToArray())
                {
                    sbMorseWord.Append(morseAlphabet.SingleOrDefault(x => x.Key == letter).Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sbMorseWord.ToString();
        }

        public Dictionary<string, string> WordToMorse(List<string> words)
        {
            Dictionary<string, string> lWordResult = new Dictionary<string, string>();
            try
            {
                foreach (string sWord in words)
                {
                    lWordResult.Add(sWord, WordToMorse(sWord));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lWordResult;
        }


        public List<MorseOption> FindWordMorse(Dictionary<string, string> lDictionary, string phrase)
        {
            StringBuilder sbFinalPhrase = new StringBuilder();
            string sPartPhrase = string.Empty;
            List<MorseOption> lMorseOption = new List<MorseOption>();
            int FirstIndex = 0;
            int Secuence = 0;
            try
            {
                do
                {

                    if (lMorseOption.Count > 0)
                    {
                        FirstIndex = lMorseOption[Secuence].FinalIndex + 1;
                        Secuence++;
                    }

                    foreach (var d in lDictionary)
                    {
                        if (phrase.Length < (FirstIndex + d.Value.Length)) // para que no se pase del array si prueba una palabra mas grande.
                        {
                            continue;
                        }

                        sPartPhrase = phrase.Substring(FirstIndex, d.Value.Length);
                        bool bExistWord = lDictionary.ContainsValue(sPartPhrase);

                        if (bExistWord)
                        {
                            lMorseOption.Add(new MorseOption(FirstIndex, d.Value.Length, d.Key, d.Value, Secuence));
                        }
                    }

                } while (Secuence < lMorseOption.Count);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lMorseOption;
        }


        public string CompletePhrase(List<MorseOption> lMorseOption)
        {
            StringBuilder sbResult = new StringBuilder();
            try
            {
                var groupedSecuence = lMorseOption.GroupBy(x => x.Secuence);

                foreach (var GroupSecuences in groupedSecuence)
                {
                    foreach (var morseOption in GroupSecuences)
                    {
                        sbResult.Append(morseOption.OriginalWord);
                        sbResult.Append(" ");
                    }
                    sbResult.AppendLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sbResult.ToString();
        }




        public List<string> ReadFileText(string path)
        {
            List<string> lWord = new List<string>();
            try
            {
                if (!File.Exists(path))
                {
                    return lWord;
                }

                lWord = File.ReadAllLines(path).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lWord;
        }


        public void GrillaDiasHoras()
        {
            List<Dia> lDias = new List<Dia>();
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            DataRow dr;
            DataColumn dcFecha1 = new DataColumn("Fecha0", typeof(string));
            DataColumn dcFecha2 = new DataColumn("Fecha1", typeof(string));
            DataColumn dcFecha3 = new DataColumn("Fecha2", typeof(string));
            DataColumn dcFecha4 = new DataColumn("Fecha3", typeof(string));
            DataColumn dcFecha5 = new DataColumn("Fecha4", typeof(string));
            dt.Columns.Add(dcFecha1);
            dt.Columns.Add(dcFecha2);
            dt.Columns.Add(dcFecha3);
            dt.Columns.Add(dcFecha4);
            dt.Columns.Add(dcFecha5);

            lDias.Add(new Dia("28/03/2023"));
            lDias.Add(new Dia("29/03/2023"));
            lDias.Add(new Dia("30/03/2023"));
            lDias.Add(new Dia("31/03/2023"));
            lDias.Add(new Dia("1/04/2023"));

            lDias[0].lHoras.Add(new Hora("01-02"));
            lDias[0].lHoras.Add(new Hora("02-03"));
            lDias[0].lHoras.Add(new Hora("04-05"));

            lDias[1].lHoras.Add(new Hora("06-07"));
            lDias[1].lHoras.Add(new Hora("08-09"));
            lDias[1].lHoras.Add(new Hora("10-11"));

            lDias[2].lHoras.Add(new Hora("12-13"));
            lDias[2].lHoras.Add(new Hora("14-15"));
            lDias[2].lHoras.Add(new Hora("16-17"));

            lDias[3].lHoras.Add(new Hora("18-19"));
            lDias[3].lHoras.Add(new Hora("20-21"));
            lDias[3].lHoras.Add(new Hora("22-23"));

            lDias[4].lHoras.Add(new Hora("24-25"));
            lDias[4].lHoras.Add(new Hora("26-27"));
            lDias[4].lHoras.Add(new Hora("28-29"));

            for (int i=0;i<lDias.Count;i++) 
            {
                dr = dt.NewRow();
                dr["Fecha" + i.ToString()] = lDias[i].Fecha;
                dt.Rows.Add(dr);
            }




        }

        public void ReadComplexJson(string sJson) 
        {
            var dynamicObject = JObject.Parse(sJson);
            string sKey;
            JToken oToken;
            int iChildrenCount;
            string sType;
            JToken oJsonChildren = null;
            string sJsonChildren;
            List<DirectoryEntity> lDirectoryEntity = new List<DirectoryEntity>();
            DirectoryEntity oDirectoryEntity = new DirectoryEntity();

            foreach (var x in dynamicObject)
            {
                sKey = x.Key;
                oToken = x.Value;
                iChildrenCount = oToken.Count();
                sType = oToken.Type.ToString();
                oDirectoryEntity.DirectoryName = sKey;
                oJsonChildren = oToken.Parent;

                if (iChildrenCount == 0) 
                {
                    
                }
                if (iChildrenCount > 0) 
                {
                    sType = oToken.Type.ToString();
                    sJsonChildren = oJsonChildren.ToString();
                    oDirectoryEntity.DirectoryReferencia = sKey;
                    lDirectoryEntity = LoadDirectoryEntity(sJsonChildren,lDirectoryEntity, oDirectoryEntity);
                }
            }
        }

        private List<DirectoryEntity> LoadDirectoryEntity(string sJson, List<DirectoryEntity> lDirectoryEntity,DirectoryEntity oDirectory) 
        {
            var dynamicObject = JObject.Parse(sJson);
            string sKey = string.Empty;
            //JToken oToken;
            //int iCountChildren=0;
            //string sType;
            //JToken oJsonChildrenFirst;
            //JToken oJsonChildrenLast;
            //string sJsonChildrenFirst;
            //string sJsonChildrenLast;

            foreach (var x in dynamicObject)
            {
                //sKey = x.Key;
                //oToken = x.Value;
                //iCountChildren = oToken.Count();
                //oDirectory.DirectoryName = sKey;
                //lDirectoryEntity.Add(oDirectory);

                //if(iCountChildren == 0) 
                //{
                //    //List<FileEntity> lFiles = JsonConvert.DeserializeObject<FileEntity>(sJson);
                //}

                //if (iCountChildren > 0)
                //{
                //    //DirectoryEntity d = new DirectoryEntity();
                    
                //    //oJsonChildrenFirst = oToken.First;
                //    //sJsonChildrenFirst = oJsonChildrenFirst.ToString();
                //    //oJsonChildrenLast = oToken.Last;
                //    //sJsonChildrenLast = oToken.Last.ToString();
                //    //d.DirectoryReferencia = sKey;
                //    //lDirectoryEntity = LoadDirectoryEntity(sJsonChildrenLast, lDirectoryEntity,d); 
                //}
            }

            return lDirectoryEntity;
        }




        public long FindTotalImbalance(int[] rank)
        {
            long ans = 0;
            int n = rank.Length;
            for (int i = 0; i < n; i++)
            {
                int cur = rank[i];
                if (cur == n || cur == (n - 1))
                {
                    continue;
                }
                int pos = i;
                for (int j = 0; j < n; j++)
                {
                    if (rank[j] == (cur + 1))
                    {
                        pos = j;
                        break;
                    }
                }
                if (pos < i)
                {
                    int left = i - pos;
                    int right = n - i;
                    ans += (long)left * right;
                }
                {
                    int left = i + 1;
                    int right = pos - i;
                    ans += (long)left * right;
                }
            }

            return ans;
        }

        public void FizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }

                if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }

                if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }

        public List<int> Fibonacci()
        {
            int acumulador = 0;
            int valorinicial = 1;
            List<int> fibo = new List<int>();

            for (int i = 0; i < 50; i++)
            {
                int temp = acumulador;
                acumulador = valorinicial;
                valorinicial = temp + acumulador;
                fibo.Add(acumulador);
            }
            return fibo;
        }

        public bool Primo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if ((numero % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public string FirstUniqueProduct(string[] products)
        {
            string sreturn = string.Empty;
            var query = products.GroupBy(x => x).Where(g => g.Count() == 1).Select(y => new { valor = y.Key }).ToList();
            sreturn = query.FirstOrDefault().ToString().Replace("{", "").Replace("}", "").Replace("valor", "").Replace("=", "").Trim();
            return sreturn;
        }

        public IEnumerable<string> AllPrefixes(int prefixLength, IEnumerable<string> words)
        {

            IEnumerable<string> result = words.Where(x => x.Length >= 3).Select(x => x.Substring(0, 3)).Distinct();
            return result;
        }

        public string WordParser(string input)
        {
            string[] lphase;
            List<string> lWord = new List<string>();
            StringBuilder sb = new StringBuilder();
            StringBuilder sbReturn = new StringBuilder();
            string sNewWord = null;
            char firstChar;
            char lastChar;
            lphase = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in lphase)
            {
                lWord.Add(word);
                sNewWord = null;

                if (word.Length > 2)
                {
                    int distinctCount = 0;
                    int k = word.Length;
                    int samecharcount = 0;
                    int j = 0;

                    for (int i = 1; i < k - 2; i++)
                    {

                        if (word[i] != word[i + 1])
                        {

                            j++;

                        }
                        else
                        {
                            samecharcount++;
                        }
                    }
                    distinctCount = j + samecharcount;
                    firstChar = word[0];
                    lastChar = word[word.Length - 1];
                    sNewWord = String.Concat(firstChar, distinctCount.ToString(), lastChar);
                    lWord.Add(sNewWord);
                    sbReturn.Append(sNewWord);
                    sbReturn.Append(" ");
                }
                else
                {
                    sbReturn.Append(sb.Append(word).Append(" "));
                }
            }
            return sbReturn.ToString();
        }

        public bool DobleDeSuma(List<int> lvalue)
        {
            //el doble de la suma de todos los numeros comparado contra el mayor producto.
            int iacumulador = 0;
            int imayorproducto = 0;
            try
            {


                foreach (int n in lvalue)
                {
                    foreach (int j in lvalue)
                    {
                        imayorproducto = n * j;
                    }

                    iacumulador += n;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (iacumulador >= imayorproducto);
        }

        public string StringChallenge(string str)
        {
            List<char> lOrden = new List<char>() { 'a', 'b', 'c', 'd', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            StringBuilder sb = new StringBuilder();
            char[] lWord;
            lWord = str.ToCharArray();

            foreach (char c in lOrden)
            {
                bool b = false;

                //letter exist.
                foreach (char w in lWord)
                {
                    if (c == w)
                    {
                        b = true;
                        break;
                    }
                }

                if (b)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el punto depende que letra quita.
        /// </summary>
        /// <param name="ops"></param>
        /// <returns></returns>
        public List<string> CalPoints(string[] ops)
        {
            List<string> list = new List<string>();
            List<string> lReturn = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                switch (ops[i])
                {
                    case "C":
                        list.RemoveAt(i);
                        list.RemoveAt(i - 1);
                        break;
                    case "D":
                        list.RemoveAt(i);
                        list[i] = (int.Parse(list[i - 2].ToString()) * int.Parse(list[i - 1].ToString())).ToString();
                        break;
                    case "+":
                        list.RemoveAt(i);
                        break;
                    default:
                        lReturn.Add(ops[i]);
                        break;
                }
            }
            return lReturn;
        }

        public int[] RotateArray(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return null;

            int[] result = new int[nums.Length];
            int arrayLength = nums.Length;
            int moveBy = k % arrayLength;

            for (int i = 0; i < arrayLength; i++)
            {
                int tmp = i + moveBy;
                if (tmp > arrayLength - 1)
                {
                    tmp = +(tmp - arrayLength);
                }
                result[tmp] = nums[i];
            }
            return result;
        }

        public void elNumero()
        {
            int[] A = { -1, 1, -2, 2 };

            int best = 0;
            if (A.Length > 1)
            {
                int current = 0, start = 0, end = 0;
                for (var i = 0; ++i < A.Length;)
                {
                    var diff = A[i] - A[i - 1];
                    if (diff >= 0)
                    {
                        if ((current += diff) > best)
                            best = current;
                        ++end;
                    }
                    else if (current + diff >= 0)
                    {
                        current += diff;
                        ++end;
                    }
                    else
                    {
                        start = end = i;
                        current = 0;
                    }
                }
            }


            Console.WriteLine(best);
        }

        public int[] ordenar(int[] array, int k)
        {
            //TODO: Add validation for K and validate that k < array.lenght
            // The first items have the latest moved
            int[] newArray = new int[array.Length];
            int count = 0;
            Console.WriteLine("saved ");
            for (int i = array.Length - k; i < array.Length; i++)
            {
                newArray[count] = array[i];
                count++;
            }
            // now just assign number to the last 
            for (int i = 0; i < array.Length - k; i++)
            {
                newArray[count] = array[i];
                count++;
                Console.Write(array[i]);
            }

            return newArray;

        }

        public string SimplificarFraccion(string Fraccion)
        {
            StringBuilder sbResult = new StringBuilder();
            int iFirstNumber;
            int iSecondNumber;
            string sFirstNumber = string.Empty;
            string sSecondNumber = string.Empty;
            List<int> lDivider = new List<int>() { 10, 5, 3, 2 };
            try
            {
                if (Fraccion.Split(@"/").Length < 2)
                {
                    throw new Exception("This not is a function");
                }

                sFirstNumber = Fraccion.Split(@"/")[0].Trim();
                sSecondNumber = Fraccion.Split(@"/")[1].Trim();
                iFirstNumber = int.Parse(System.Text.RegularExpressions.Regex.Replace(sFirstNumber, "/d", ""));
                iSecondNumber = int.Parse(System.Text.RegularExpressions.Regex.Replace(sSecondNumber, "/d", ""));

                foreach (int iDivider in lDivider)
                {
                    while (iFirstNumber % iDivider == 0 && iSecondNumber % iDivider == 0)
                    {
                        iFirstNumber = iFirstNumber / iDivider;
                        iSecondNumber = iSecondNumber / iDivider;
                    }
                }

                sbResult.Append(iFirstNumber);
                if (iSecondNumber != 1)
                {
                    sbResult.Append("/");
                    sbResult.Append(iSecondNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sbResult.ToString();
        }

        public bool ValidName(string Name)
        {
            bool isValid = true;
            List<char> lSeparator = new List<char>() { '.', ' ' };
            try
            {

                if (Name == null)
                {
                    throw new ApplicationException("Name Cannot be NULL!");
                }

                if (Name.Trim().Length == 0)
                {
                    throw new ApplicationException("Name Cannot be Empty");
                }

                if (Name.Trim().Length <= 3)
                {
                    throw new ApplicationException("Name Cannot is a name");
                }

                //Could be one word
                if (Name.Contains(' ') == false && Name.Contains('.') == false)
                {
                    return false;
                }

                //First word cannot contain a dot
                if (Name.Split(' ').Length == 2 && Name.Split(' ')[0].Length == 1)
                {
                    return false;
                }

                //First word cannot contain a dot
                if (Name.Split(' ').Length == 2 && Name.Split(' ')[0].Length == 2)
                {
                    if (Name.Split(' ')[0].Substring(1, 1) != ".")
                    {
                        return false;
                    }
                }

                //second word cannot contain a dot or the second word is too long
                if (Name.Split(' ').Length == 3 && (Name.Split(' ')[1].Length == 1 || Name.Split(' ')[1].Length > 2))
                {
                    return false;
                }

                //First word cannot contain a dot
                if (Name.Split(' ').Length == 3 && Name.Split(' ')[1].Length == 2)
                {
                    if (Name.Split(' ')[0].Substring(1, 1) != ".")
                    {
                        return false;
                    }
                }

                //Common validation
                foreach (char c in lSeparator)
                {
                    //Capital Letter First Word
                    if (Name.Split(c).Length >= 2 && Name.Split(c)[0].Substring(0, 1) != Name.Split(c)[0].Substring(0, 1).ToUpper())
                    {
                        return false;
                    }

                    //Capital Letter Second Word
                    if (Name.Split(c).Length >= 2 && Name.Split(c)[1].Substring(0, 1) != Name.Split(c)[1].Substring(0, 1).ToUpper())
                    {
                        return false;
                    }

                    //Second word could be a surname
                    if (Name.Split(c)[Name.Split(c).Length - 1].Length < 2)
                    {
                        return false;
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isValid;
        }



        public long getHeaviestPackage(List<int> packageWeights)
        {
            long max = 0;
            for (int i = packageWeights.Count - 1; i >= 0; --i)
            {
                if (packageWeights[i] < max)
                {
                    max += packageWeights[i];
                }
                else
                {
                    max = packageWeights[i];
                }
            }
            return max;
        }


        public int FindMaximumPossibleValue(int value)
        {
            int j = 0;
            int iTemp;
            StringBuilder sbResult = new StringBuilder();

            if (value == 0) //Si es igual a cero
            {
                return 50;
            }

            if (value < 0) //Si es menor
            {
                iTemp = Math.Abs(value);
                foreach (char c in iTemp.ToString())
                {
                    if (int.Parse(iTemp.ToString()[0].ToString()) > 5)
                    {
                        sbResult.Append("-5");
                        sbResult.Append(iTemp);
                        return int.Parse(sbResult.ToString());
                    }
                    if (int.Parse(c.ToString()) < 5)
                    {
                        j += 1;
                    }
                }

                sbResult.Append("-");
                sbResult.Append(iTemp.ToString().Substring(0, j));
                sbResult.Append(5);
                sbResult.Append(iTemp.ToString().Substring(j));

                return int.Parse(sbResult.ToString());
            }

            foreach (char c in value.ToString())
            {
                
                if (int.Parse(value.ToString()[0].ToString()) < 5)
                {
                    sbResult.Append(5);
                    sbResult.Append(value);
                    return int.Parse(sbResult.ToString());
                }

                if (int.Parse(c.ToString()) > 5)
                {
                    j += 1;
                }
            }

            sbResult.Append(value.ToString().Substring(0, j));
            sbResult.Append(5);
            sbResult.Append(value.ToString().Substring(j));

            return int.Parse(sbResult.ToString());
        }


        /// <summary>
        /// Cuantos 1 maximos hay en la cadena
        /// {0,0,1,1,1,0,0,0,1,1,1,1,1}; = 5
        /// </summary>
        /// <param name="arrayvalue"></param>
        /// <returns></returns>
        public int MaximalBinaryOnesSpan(int[] arrayvalue)
        {
            int icount = 0;
            int iresult = 0;

            for (int i = 0; i < arrayvalue.Length; i++)
            {
                if (arrayvalue[i] == 0)
                {
                    icount = 0;
                }
                else
                {
                    icount++;
                    iresult = Math.Max(iresult, icount);
                }
            }
            return iresult;
        }



        /// <summary>
        /// Encuentra el indice de los binarios.
        /// </summary>
        /// <returns></returns>
        public int FindFirstSecuenceWhosLenghtEqualOne(int[] A) 
        {
            // n is the length of the array 
            int n = A.Length;
            int i = n - 1;
            // the result starts in -1
            int result = -1;
            // counter of ones.
            int k = 0,
            // max number of ones found 
            maximal = 0;

            // lets go backwards
            while (i >= 0)
            {
                // if its 1 lets count
                if (A[i] == 1)
                {
                    k = k + 1;
                    //replace position if its bigger or iqual to max. 
                    if (k >= maximal)
                    {
                        maximal = k;
                        result = i;
                    }
                }
                else
                {
                    // reset counter of ones.
                    k = 0;
                }
                i = i - 1;
            }

            return result;
        }


        /// <summary>
        /// devuelve la suma de las edades proporcionadas en el parametro age
        /// </summary>
        /// <param name="data"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public int CountItemsWithAgeGreaterThanEqual(string data, int age)
        {
            string s;
            s = data.Replace("{", "").Replace("\"", "").Replace("}", "").Replace("data:", "");
            string[] items = s.Split(", ");
            int count = 0;
            foreach (string item in items)
            {
                if (item.Contains("age="))
                {
                    int itemAge = int.Parse(item.Split("=")[1]);
                    if (itemAge >= age)
                    {
                        count++;
                    }
                }
            }
            return count;
        }



    }
}
