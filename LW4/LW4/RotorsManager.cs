using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class RotorsManager
    {
        string alphabet;
        List<Rotor> rotors;
        Reflector reflector;
        public  RotorsManager ( string alphabet)
        {
            this.alphabet = alphabet;
            rotors = new List<Rotor>();
        }

        public void LoadRotor(Rotor rotor)
        {
            rotors.Add(rotor);
        }

        public void SetReflector(Reflector reflector)
        {
            this.reflector = reflector;
        }

        public void moveRotor()
        {
            for( int i=0;i<rotors.Count;i++)
                rotors[i].TakeStep((i>0)? rotors[i-1] : null);
        }

        public char EncryptCharacter( char character)
        {
            char encryptCharacter = character;
            foreach ( Rotor rotor in rotors)
                encryptCharacter = rotor.Alphabet[alphabet.IndexOf(encryptCharacter)];
            encryptCharacter = reflector.GetReplaceCharacter(encryptCharacter);
            for (int i = rotors.Count-1; i >= 0; i--)
                encryptCharacter = rotors[i].Alphabet[alphabet.IndexOf(encryptCharacter)];
            return encryptCharacter;
        }

        public char DecryptCharacter( char character)
        {
            char encryptCharacter = character;
            for (int i = rotors.Count; i >= 0; i--)
                encryptCharacter = rotors[i].Alphabet[alphabet.IndexOf(encryptCharacter)];
            encryptCharacter = reflector.GetReplaceCharacter(encryptCharacter);
            foreach (Rotor rotor in rotors)
                encryptCharacter = rotor.Alphabet[alphabet.IndexOf(encryptCharacter)];
            return encryptCharacter;
        }
           
    }
}
