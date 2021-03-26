using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class Reflector
    {
        string alphabet;
        string replaceAlphabet;

        public Reflector ( string alphabet, string replaceAlphabet)
        {
            this.alphabet = alphabet;
            this.replaceAlphabet = replaceAlphabet;
        }

        public char GetReplaceCharacter(char character) => replaceAlphabet[alphabet.IndexOf(character)];
    }
}
