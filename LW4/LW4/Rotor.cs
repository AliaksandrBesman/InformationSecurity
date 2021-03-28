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
        readonly int step;
        int currentPosition;
        bool revolution;

        public Rotor(string alphabet, int step)
        {
            this.alphabet = alphabet;
            this.step = step;
        }

        public string Alphabet { get => alphabet; }
        public bool Revolution { get => revolution; }
        public void ReactToPrevioslyRotorTurn() => revolution = false;

        public void TakeStep(Rotor previouslyRotor)
        {
            int step = this.step;
            if (step == 0)
            {
                if (previouslyRotor.Revolution)
                {
                    step = 1;
                    previouslyRotor.ReactToPrevioslyRotorTurn();
                }
                else
                    return;
            }
            string stepCharacters = alphabet.Substring(0, step);
            alphabet = alphabet.Substring(step) + stepCharacters;
            currentPosition += step;
            if (currentPosition > alphabet.Length)
            {
                revolution = true;
                currentPosition = currentPosition - alphabet.Length;
            }

        }
    }
}
