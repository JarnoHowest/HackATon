using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathA
{
    public class MayaDecoder
    {
        public Dictionary<char, char> alphabet;

        public MayaDecoder()
        {
            alphabet = HieroglyphAlphabet.Characters;
        }

    public string Decode(string input)
        {
            string decodedString = "";

            foreach (char c in input)
            {
                try
                {
                    var value = alphabet[c];
                    decodedString += value;
                } catch (Exception e)
                {
                    decodedString += c;
                }

            }
            return decodedString;
        }
    }
}
