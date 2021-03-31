using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5
{
    class SubKeysManager
    {
        string textKey,
               asciiKey,
               asciiKeyPlus;
        string[] C0;
        string[] D0;
        string[] K;

        public SubKeysManager(string textKey)
        {
            this.textKey = textKey;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char character in textKey)
                stringBuilder.Append(ASCIIHelper.CharToBits(character));
            asciiKey = stringBuilder.ToString();
            C0 = new string[17];
            D0 = new string[17];
            PermutationHelper.Permute(asciiKey, PermutationHelper.Pc1, out asciiKeyPlus);
            Console.WriteLine("K = " + asciiKey);
            Console.WriteLine("K+ = " + asciiKeyPlus);
            MakeKeys();
        }

        public string[] K1 { get => K; set => K = value; }

        private void MakeKeys()
        {
            string[] C0 = new string[17];
            string[] D0 = new string[17];
            C0[0] = asciiKeyPlus.Substring(0, asciiKeyPlus.Length / 2);
            D0[0] = asciiKeyPlus.Substring(asciiKeyPlus.Length / 2);
            Console.WriteLine("C0 = "+C0[0]);
            Console.WriteLine("D0 = "+D0[0]);
            //Make Shifts for all keys sequence
            for(int i = 1; i<=16;i++)
            {
                C0[i] = C0[i - 1].Substring(PermutationHelper.IterationLeftShifts[i]) + C0[i - 1].Substring(0, PermutationHelper.IterationLeftShifts[i]);
                D0[i] = D0[i - 1].Substring(PermutationHelper.IterationLeftShifts[i]) + D0[i - 1].Substring(0, PermutationHelper.IterationLeftShifts[i]);
                Console.WriteLine($"C{i} = " + C0[i]);
                Console.WriteLine($"D{i} = " + D0[i]);
            }
            K = new string[16];
            //Make keys via permutation
            for (int i = 0; i < 16; i++)
            {
                PermutationHelper.Permute(C0[i + 1] + D0[i + 1], PermutationHelper.Pc2, out K[i]);
                Console.WriteLine($"K{i+1} = " + K[i]);
            }
        }


    }
}
