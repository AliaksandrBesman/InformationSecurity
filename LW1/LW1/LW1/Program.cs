using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW1
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 450;
            int n = 530;
            int oneValue = 50;
            Console.WriteLine("NOD for 2 nums: " + NodHelper.calculateNode2(n, m));
            Console.WriteLine("NOD for 3 nums: " + NodHelper.calculateNod3(54, 27, 9));
            Console.WriteLine($"Count of prime nums [{m}, {n}]: " + PrimeNumHelper.CountPrimeNums(m, n));
            Console.WriteLine($"Count of prime nums [{m}, {n}]: " + PrimeNumHelper.CountPrimeNums(m, n));
            Console.WriteLine("Prime Nums [800;830]");
            var primeNums = PrimeNumHelper.CalculatePrimeNumsByEratosthenesSieve(m, n);
            for (int i = 0; i < primeNums.Count; i++)
                Console.Write(primeNums[i].ToString() + " ");
            Console.WriteLine();
            Console.WriteLine("Count prim nums : " + primeNums.Count.ToString());

            PrimeNumHelper.PrintCancatenateFormForNumber(PrimeNumHelper.CaclulatePrimeNumsByEratosthenesSieve(m), m);
            PrimeNumHelper.PrintCancatenateFormForNumber(PrimeNumHelper.CaclulatePrimeNumsByEratosthenesSieve(oneValue), oneValue);
            Console.WriteLine("Count prime nums by log: " + Math.Round(oneValue / Math.Log(oneValue)));
        }
    }
}
