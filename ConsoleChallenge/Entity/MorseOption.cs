using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenge.Entity
{
    public class MorseOption
    {

        public MorseOption() { }

        public MorseOption(int firstindex, int finalindex, string originalword, string morseword, int secuence)
        {
            FirstIndex = firstindex;
            FinalIndex = finalindex;
            OriginalWord = originalword;
            MorseWord = morseword;
            Secuence = secuence;
        }

        public int Secuence { get; set; }
        public int FirstIndex { get; set; }
        public int FinalIndex { get; set; }
        public string OriginalWord { get; set; }
        public string MorseWord { get; set; }
    }
}
