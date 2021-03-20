using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW3
{
    class CharacterHelper
    {
        static public Dictionary<char, int> dictionaryCharacterIndexes;
        static CharacterHelper()
        {
            dictionaryCharacterIndexes = new Dictionary<char, int>();
            string dictionary = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < dictionary.Length; i++)
                dictionaryCharacterIndexes.Add(dictionary[i],i);
            

        }
    }
}
