using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW2
{
    class VigenereHelper
    {
        string dictionary;
        int N;
        public void LoadDictionary(string dictionary)
        {
            this.dictionary = dictionary;
            N = dictionary.Length;
        }
        //зашифровать
        public string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int c = (dictionary.IndexOf(symbol) +
                    dictionary.IndexOf(keyword[keyword_index])) % N;
                result += dictionary[c];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
        //расшифровать
        public string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int p = (dictionary.IndexOf(symbol) + N -
                    dictionary.IndexOf(keyword[keyword_index])) % N;
                result += dictionary[p];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
    }
}
