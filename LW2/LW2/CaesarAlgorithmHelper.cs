using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW2
{
    class CaesarAlgorithmHelper
    {
        int N, //Alphabet size
            a, b,
            inverseA;
        string alphabet;

        public void LoadAlphabet(string dictionary)
        {
            alphabet = dictionary;
            N = dictionary.Length;
        }

        private int EncryptCharacterByCaesarSAffinitySystem(int index) => (a * index + b)%N;
       
        public string EncryptMessageByCaesarSAffinitySystem(string message, int a, int b)
        {
            this.a = a;
            this.b = b;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char character in message)
                stringBuilder.Append(alphabet[EncryptCharacterByCaesarSAffinitySystem(alphabet.IndexOf(character))]);
            return stringBuilder.ToString();
        }

        private int DecryptCharacterByCaesarSAffinitySystem(int index) => (inverseA*(index + N - b)) % N;

        public string DecryptMessageByCaesarSAffinitySystem(string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            inverseA = (int)Inverse(a, N);
            foreach (char character in message)
                stringBuilder.Append(alphabet[DecryptCharacterByCaesarSAffinitySystem(alphabet.IndexOf(character))]);
            return stringBuilder.ToString();
        }
        public static void Extended_euclid(long a, long b, out long x, out long y, out long d)
        /* calculates a * *x + b * *y = gcd(a, b) = *d */
        {
            long q, r, x1, x2, y1, y2;

            if (b == 0)
            {
                d = a; x = 1; y = 0;
                return;
            }
            x2 = 1; x1 = 0; y2 = 0; y1 = 1;

            while (b > 0)
            {
                q = a / b; r = a - q * b;
                x = x2 - q * x1; y = y2 - q * y1;
                a = b; b = r;
                x2 = x1; x1 = x; y2 = y1; y1 = y;
            }

            d = a; x = x2; y = y2;
        }

        public static long Inverse(long a, long n)
        /* computes the inverse of a modulo n */
        {
            long d, x, y;
            Extended_euclid(a, n, out x, out y, out d);
            if (d == 1) return x;
            return 0;

        }

    }
}
