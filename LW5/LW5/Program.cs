using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5
{
    class Program
    {
        static void Main(string[] args)
        {
            string asciiChar = Convert.ToString('f', 2).PadLeft(8, '0');
            Console.WriteLine(asciiChar);
            Console.WriteLine("2: " + ASCIIHelper.ASCIINumberToInt("10"));
            Console.WriteLine("4: " + ASCIIHelper.ASCIINumberToInt("100"));
            Console.WriteLine("7: " + ASCIIHelper.ASCIINumberToInt("111"));
            Console.WriteLine("10: " + ASCIIHelper.IntToASCIINumber(10));
            Console.WriteLine("11: " + ASCIIHelper.IntToASCIINumber(11));
      
            string key = ASCIIHelper.BitsToChar("0001001100110100010101110111100110011011101111001101111111110001");
            //SubKeysManager subKeysManager = new SubKeysManager(key);
            DESHelper dESHelper = new DESHelper(key);
            string encryptMessage = dESHelper.Encrypt("0000000100100011010001010110011110001001101010111100110111101111");
            string decryptMessage = dESHelper.Decrypt(encryptMessage);
        }

    }
}
