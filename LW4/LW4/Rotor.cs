using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class Rotor
    {
        string alphabet;

        int step;

        public Rotor(string alphabet,int step)
        {
            this.alphabet = alphabet;
            this.step = step;
        }

        public string Alphabet { get => alphabet; }

        public void TakeStep(Rotor previouslyRotor)
        {
            string stepCharacters = alphabet.Substring(0, step);
            alphabet = alphabet.Substring(step) + stepCharacters;
        }
    }
}
