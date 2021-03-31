using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5
{
    static class ASCIIHelper
    {
        public static string CharToBits(Char value) => Convert.ToString(value, 2).PadLeft(8, '0');

        private static Char ConvertToChar(String value)
        {
            int result = 0;

            foreach (Char ch in value)
                result = result * 2 + ch - '0';

            return (Char)result;
        }

        public static string BitsToChar(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            StringBuilder Sb = new StringBuilder();

            for (int i = 0; i < value.Length / 8; ++i)
                Sb.Append(ConvertToChar(value.Substring(8 * i, 8)));

            return Sb.ToString();
        }

        public static string XORTwoStringSequenceBits(string value1, string value2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < value1.Length; i++)
                stringBuilder.Append(((int.Parse(value1[i].ToString()) + int.Parse(value2[i].ToString()))%2).ToString());
            return stringBuilder.ToString();
        }

        public static int ASCIINumberToInt(string asciiNumber)
        {
            asciiNumber = asciiNumber.PadLeft(8, '0');
            int number = 0;
            for (int i = 0; i <= 7; i++)
                number += int.Parse(asciiNumber[i].ToString()) * (int)Math.Pow(2,7-i);
            return number;
        }

        public static string IntToASCIINumber(int number)
        {
            int ost;
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                ost = number % 2;
                number /= 2;
                stringBuilder.Append(ost);
            } while (number != 0);

            return ReverseString(stringBuilder.ToString()).PadLeft(8, '0');
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
