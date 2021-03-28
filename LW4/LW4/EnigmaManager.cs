using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class EnigmaManager
    {
        string alphabet;
        List<Rotor> rotors;
        Reflector reflector;

        public EnigmaManager(string alphabet)
        {
            this.alphabet = alphabet;
            rotors = new List<Rotor>();
        }

        public void LoadRotor(Rotor rotor) //Right to Left
        {
            rotors.Add(rotor);
        }

        public void SetReflector(Reflector reflector)
        {
            this.reflector = reflector;
        }

        private void MoveRotor()
        {
            for (int i = 0; i < rotors.Count; i++)
                rotors[i].TakeStep((i > 0) ? rotors[i - 1] : null);
        }

        public char EncryptDecryptCharacter(char character)
        {
            //go ahead
            foreach (Rotor rotor in rotors)
                character = rotor.Alphabet[alphabet.IndexOf(character)];
            character = reflector.GetReplaceCharacter(character);
            //go back
            for (int i = rotors.Count - 1; i >= 0; i--)
                character = alphabet[rotors[i].Alphabet.IndexOf(character)];
            MoveRotor();
            return character;
        }
    }
}
