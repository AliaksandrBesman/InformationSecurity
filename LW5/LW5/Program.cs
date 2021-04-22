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
            //string asciiChar = Convert.ToString('f', 2).PadLeft(8, '0');
            //Console.WriteLine(asciiChar);
            //Console.WriteLine("2: " + ASCIIHelper.ASCIINumberToInt("10"));
            //Console.WriteLine("4: " + ASCIIHelper.ASCIINumberToInt("100"));
            //Console.WriteLine("7: " + ASCIIHelper.ASCIINumberToInt("111"));
            //Console.WriteLine("10: " + ASCIIHelper.IntToASCIINumber(10));
            //Console.WriteLine("11: " + ASCIIHelper.IntToASCIINumber(11));
            //string keey1 = "LOKLKOLF";
            //string keey2 = "JIKLOPLK";

            //string key = ASCIIHelper.BitsToChar("0001001100110100010101110111100110011011101111001101111111110001");

            ////SubKeysManager subKeysManager = new SubKeysManager(key);
            //DESHelper dESHelper = new DESHelper(key);
            //DESHelper dESHelper2 = new DESHelper(key);
            //DESHelper dESHelper3 = new DESHelper(key);
            //string encryptMessage = dESHelper.Encrypt("0000000100100011010001010110011110001001101010111100110111101111");
            //string encryptMessage2 = dESHelper2.Encrypt(encryptMessage);
            //string encryptMessage3 = dESHelper2.Encrypt(encryptMessage2);
            //string decryptMessage = dESHelper.Decrypt(encryptMessage);

            ///
            string keey1 = "HELLOWOR";
            string keey2 = "JIKLOPLK";
            DESHelper dESHelper1 = new DESHelper(keey1);
            DESHelper dESHelper2 = new DESHelper(keey2);
            DESHelper dESHelper3 = dESHelper1;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char character in "PRIVET M")
            {
                stringBuilder.Append(ASCIIHelper.CharToBits(character));
            }
            string encryptMessage = dESHelper1.Encrypt(stringBuilder.ToString());
            string encryptMessage2 = dESHelper2.Encrypt(encryptMessage);
            string encryptMessage3 = dESHelper3.Encrypt(encryptMessage2);
            Console.WriteLine("EncryptMessage : " + ASCIIHelper.BitsToChar(encryptMessage3));
            string decryptMessage = dESHelper3.Decrypt(encryptMessage3);
            string decryptMessage2 = dESHelper2.Decrypt(decryptMessage);
            string decryptMessage3 = dESHelper1.Decrypt(decryptMessage2);
            Console.WriteLine("DecryptMessage : " + ASCIIHelper.BitsToChar(decryptMessage3));
        }

    }
}
