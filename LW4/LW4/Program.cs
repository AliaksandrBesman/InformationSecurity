using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encrypt
            EnigmaManager enigma = new EnigmaManager(RotorsConstants.inputValue);
            enigma.LoadRotor(new Rotor(RotorsConstants.rotorII, 1));
            enigma.LoadRotor(new Rotor(RotorsConstants.rotorIII, 0));
            enigma.LoadRotor(new Rotor(RotorsConstants.rotorV, 1));
            enigma.SetReflector(new Reflector(ReflectorsConstants.reflectorC));
            string message = "HELLOWORLD";
            StringBuilder encryptMessage = new StringBuilder();
            foreach (char input in message)
                encryptMessage.Append(enigma.EncryptDecryptCharacter(input));
            Console.WriteLine(encryptMessage);
            //Decrypt
            EnigmaManager enigma2 = new EnigmaManager(RotorsConstants.inputValue);
            enigma2.LoadRotor(new Rotor(RotorsConstants.rotorII, 1));
            enigma2.LoadRotor(new Rotor(RotorsConstants.rotorIII, 0));
            enigma2.LoadRotor(new Rotor(RotorsConstants.rotorV, 1));
            enigma2.SetReflector(new Reflector(ReflectorsConstants.reflectorC));
            StringBuilder decryptMessage = new StringBuilder();
            foreach (char input in encryptMessage.ToString())
                decryptMessage.Append(enigma2.EncryptDecryptCharacter(input));
            Console.WriteLine(decryptMessage);



        }
    }
}
