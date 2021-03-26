using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW2
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = 5, b = 999, d, x, y;

            CaesarAlgorithmHelper.Extended_euclid(a, b, out x, out y, out d);
            Console.WriteLine($"x = {x} y = {y} d = {d}");
            Console.WriteLine(CaesarAlgorithmHelper.Inverse(17, 999));

            string dictionary = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            CaesarAlgorithmHelper caesarAlgorithm = new CaesarAlgorithmHelper();
            caesarAlgorithm.LoadAlphabet(dictionary);
            string message = "VENIVIDIVICI";
            Console.WriteLine("Message: " + message);
            string encryptMessage = caesarAlgorithm.EncryptMessageByCaesarSAffinitySystem(message,3,5);
            Console .WriteLine ( "Encrypt message: " + encryptMessage) ;
            string decryptMessage = caesarAlgorithm.DecryptMessageByCaesarSAffinitySystem(encryptMessage);
            Console.WriteLine("Decrypt message: " + decryptMessage);

            //Виженер
            VigenereHelper vigenereHelper = new VigenereHelper();
            vigenereHelper.LoadDictionary(dictionary);
            Console.WriteLine("Start message frequency");
            FrequencyHelper.CalculateFrequency(message);
             encryptMessage = vigenereHelper.Encode(message,"ALEX");
            Console.WriteLine("Encrypt message: " + encryptMessage);
            Console.WriteLine("Encrypt message frequency");
            FrequencyHelper.CalculateFrequency(encryptMessage);
            decryptMessage = vigenereHelper.Decode(encryptMessage,"ALEX");
            Console.WriteLine("Decrypt message: " + decryptMessage);
        }
    }
}
