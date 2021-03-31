using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW5
{
    class DESHelper
    {
        string block64;
        string ip;
        SubKeysManager subKeysManager;
        public DESHelper(string textKey)
        {
            subKeysManager = new SubKeysManager(textKey);
        }

        public string Encrypt(string block64)
        {
            this.block64 = block64;
            Console.WriteLine("M = " + this.block64);
            PermutationHelper.Permute(this.block64, PermutationHelper.Ip, out ip);
            Console.WriteLine("IP = " + ip);
            string[] L = new string[17];
            string[] R = new string[17];
            L[0] = ip.Substring(0, ip.Length / 2);
            R[0] = ip.Substring(ip.Length / 2);
            Console.WriteLine("L0 = " + L[0]);
            Console.WriteLine("R0 = " + R[0]);
            for (int i = 1; i <= 16; i++)
            {
                L[i] = R[i - 1];
                Console.WriteLine($"L{i} = " + L[i]);
                Console.WriteLine($"K{i - 1} = " + subKeysManager.K1[i - 1]);
                string ER, KER;
                PermutationHelper.Permute(R[i - 1], PermutationHelper.E_bit_selection, out ER);
                Console.WriteLine($"ER{i} = " + ER);
                KER = ASCIIHelper.XORTwoStringSequenceBits(ER, subKeysManager.K1[i - 1]);
                Console.WriteLine($"KER{i} = " + KER);
                StringBuilder stringBuilder = new StringBuilder();
                //6Bits To 4 Bist
                for (int ii = 0; ii < KER.Length / 6; ii++)
                    stringBuilder.Append(PermutationHelper.Crypt6BistTo4Bist(KER.Substring(ii * 6, 6), PermutationHelper.S, ii));
                string SB = stringBuilder.ToString();
                Console.WriteLine($"SB{i} = " + SB);
                string SBP;
                PermutationHelper.Permute(SB, PermutationHelper.P, out SBP);
                Console.WriteLine($"SBP{i} = " + SBP);
                R[i] = ASCIIHelper.XORTwoStringSequenceBits(L[i - 1], SBP);
                Console.WriteLine($"R{i} = " + R[i]);
            }
            string reverse = R[16] + L[16];
            Console.WriteLine("Reverse Final 16 roud = " + reverse);
            string ecncryptBlok;
            PermutationHelper.Permute(reverse, PermutationHelper.Ip_1, out ecncryptBlok);
            Console.WriteLine("ecncryptBlok = " + ecncryptBlok);
            return ecncryptBlok;
        }
        public string Decrypt(string block64)
        {
            //Just Encrypt with Reverse Keys Sequence
            this.block64 = block64;
            Console.WriteLine("M = " + this.block64);
            PermutationHelper.Permute(this.block64, PermutationHelper.Ip, out ip);
            Console.WriteLine("IP = " + ip);
            string[] L = new string[17];
            string[] R = new string[17];
            L[0] = ip.Substring(0, ip.Length / 2);
            R[0] = ip.Substring(ip.Length / 2);
            Console.WriteLine("L0 = " + L[0]);
            Console.WriteLine("R0 = " + R[0]);
            for (int i = 1; i <= 16; i++)
            {
                L[i] = R[i - 1];
                Console.WriteLine($"L{i} = " + L[i]);
                Console.WriteLine($"K{16 - i} = " + subKeysManager.K1[16 - i]);
                string ER, KER;
                PermutationHelper.Permute(R[i - 1], PermutationHelper.E_bit_selection, out ER);
                Console.WriteLine($"ER{i} = " + ER);
                KER = ASCIIHelper.XORTwoStringSequenceBits(ER, subKeysManager.K1[16 - i]);
                Console.WriteLine($"KER{i} = " + KER);
                StringBuilder stringBuilder = new StringBuilder();
                //6Bits To 4 Bist
                for (int ii = 0; ii < KER.Length / 6; ii++)
                    stringBuilder.Append(PermutationHelper.Crypt6BistTo4Bist(KER.Substring(ii * 6, 6), PermutationHelper.S, ii));
                string SB = stringBuilder.ToString();
                Console.WriteLine($"SB{i} = " + SB);
                string SBP;
                PermutationHelper.Permute(SB, PermutationHelper.P, out SBP);
                Console.WriteLine($"SBP{i} = " + SBP);
                R[i] = ASCIIHelper.XORTwoStringSequenceBits(L[i - 1], SBP);
                Console.WriteLine($"R{i} = " + R[i]);
            }
            string reverse = R[16] + L[16];
            Console.WriteLine("Reverse Final 16 roud = " + reverse);
            string ecncryptBlok;
            PermutationHelper.Permute(reverse, PermutationHelper.Ip_1, out ecncryptBlok);
            Console.WriteLine("ecncryptBlok = " + ecncryptBlok);
            return ecncryptBlok;
        }

    }
}
