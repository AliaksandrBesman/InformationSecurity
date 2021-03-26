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
          
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabet2 = "NOPQRSTUVWXYZABCDEFGHIJKLM";
            string alphabet3 = "DEFGHIJUVWXYZABCKLMNOPQRST";
            string alphabet4 = "ABCKLMNDEFGHIJUVWXYZOPQRST";
            RotorsManager rotorsManager = new RotorsManager(alphabet);
            rotorsManager.LoadRotor(new Rotor(alphabet2, 1));
            rotorsManager.LoadRotor(new Rotor(alphabet3, 2));
            rotorsManager.SetReflector(new Reflector(alphabet, alphabet4));
           char ecnryptCharacter =  rotorsManager.EncryptCharacter('M');
            Console.WriteLine(ecnryptCharacter);
            RotorsManager rotorsManager2 = new RotorsManager(alphabet);
            rotorsManager2.LoadRotor(new Rotor(alphabet2, 1));
            rotorsManager2.LoadRotor(new Rotor(alphabet3, 2));
            rotorsManager2.SetReflector(new Reflector(alphabet, alphabet4));
            char denryptCharacter = rotorsManager.EncryptCharacter(ecnryptCharacter);
            Console.WriteLine(denryptCharacter);
        }
    }
}
