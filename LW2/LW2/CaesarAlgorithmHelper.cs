using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW2
{
    class CaesarAlgorithmHelper
    {
        int N, a, b;
        Dictionary<int, char> mainDictionary;
        Dictionary<char, char> encryptDictionary;
        Dictionary<char, char> decryptDictionary;

        public void LoadDictionary(string dictionary)
        {
            for (int i = 0; i < dictionary.Length; i++)
                mainDictionary.Add(i, dictionary[i] );
            N = dictionary.Length;
        }

       public CaesarAlgorithmHelper()
        {
            mainDictionary = new Dictionary<int, char>();
            encryptDictionary = new Dictionary<char, char>();
            decryptDictionary = new Dictionary<char, char>();
        }


        private void GenerateEncryptDictionary()
        {
            for (int i = 0; i < mainDictionary.Count; i++)
            encryptDictionary.Add(mainDictionary[i], mainDictionary[EncryptCharacter(i)]);
            decryptDictionary = encryptDictionary.ToDictionary(p=>p.Value,p=>p.Key );
            
        }
        private int EncryptCharacter(int index) => (a * index + b)%N;
       
        public string EncryptCaesarSAffinitySystem(string message, int a, int b)
        {
            this.a = a;
            this.b = b;
            GenerateEncryptDictionary();
            StringBuilder stringBuilder = new StringBuilder(message);
            for (int i = 0; i < message.Length; i++)
                stringBuilder[i] = encryptDictionary[stringBuilder[i]];
            return stringBuilder.ToString();
        }

        public string DecryptCaesarSAffinitySystem(string message)
        {
            StringBuilder stringBuilder = new StringBuilder(message);
            for (int i = 0; i < message.Length; i++)
                stringBuilder[i] = decryptDictionary[stringBuilder[i]];
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
