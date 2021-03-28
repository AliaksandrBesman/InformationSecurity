using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class Reflector
    {
        Dictionary<char, char> valuePairs;

        public Reflector(Dictionary<char, char> valuePairs)
        {
            this.valuePairs = valuePairs;
        }

        public char GetReplaceCharacter(char character) => valuePairs[character];
    }
}
