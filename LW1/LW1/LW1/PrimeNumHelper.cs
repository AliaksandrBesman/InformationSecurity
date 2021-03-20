using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW1
{
    class PrimeNumHelper
    {
        public static int CountPrimeNums(int st, int end)
        {
            int count = end - st + 1;
            int nod = 0;

            int result = 0;
            int ost = 0;
            for (int i = st; i <= end; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    int del = NodHelper.calculateNode2(i, j);

                    if (i % j == 0)
                        if (Math.Floor(Convert.ToDouble(i / j)) != 1 || Math.Floor(Convert.ToDouble(i / j)) != i)
                            nod++;

                    if (nod > 2)
                    {
                        count--;
                        break;
                    }
                }
                nod = 0;
            }
            return count;
        }



        public static List<int> CalculatePrimeNumsByEratosthenesSieve(int st, int end)
        {
            int maxNumForCheckPrimeRange = (int)Math.Sqrt(end);
            List<int> primeNumHelperList = new List<int>();
            //Add First checked sequence
            for (int i = 2; i <= maxNumForCheckPrimeRange; i++)
                primeNumHelperList.Add(i);
            //add Last checked sequence
            for (int i = st; i <= end; i++)
                primeNumHelperList.Add(i);
            //Check Prime Numbers
            primeNumHelperList = primeNumHelperList.OrderBy(p => p).ToList();
            do
            {
                int currnetChekedNum = primeNumHelperList[0];
                if (currnetChekedNum >= st)
                    break;
                primeNumHelperList = primeNumHelperList.Where(p => p % currnetChekedNum != 0).ToList();
            } while (true);
            return primeNumHelperList;

        }

        //public static List<int> CaclulatePrimeNumsByEratosthenesSieve(int end)
        //{

        //    List<int> primeNumHelperList = new List<int>();
        //    //Add First checked sequence
        //    for (int i = 2; i <= end; i++)
        //        primeNumHelperList.Add(i);

        //    //Check Prime Numbers
        //    primeNumHelperList = primeNumHelperList.OrderBy(p => p).ToList();
        //    int couner = 0;
        //    int startCountNums = 0;
        //    int endCountNums = -1;
        //    do
        //    {

        //        int currnetChekedNum = primeNumHelperList[couner];
        //        primeNumHelperList = primeNumHelperList.Where(p => p % currnetChekedNum != 0).ToList();
        //        primeNumHelperList.Insert(couner, currnetChekedNum);
        //        endCountNums = primeNumHelperList.Count;
        //        couner++;



        //    } while (startCountNums != endCountNums);
        //    return primeNumHelperList;

        //} 
        public static List<int> CaclulatePrimeNumsByEratosthenesSieve(int end)
        {
            int maxNumForCheckPrimeRange = (int)Math.Sqrt(end);
            List<int> primeNumHelperList = new List<int>();
            //add checked sequence
            for (int i = 2; i <= end; i++)
                primeNumHelperList.Add(i);
            //Check Prime Numbers
            primeNumHelperList = primeNumHelperList.OrderBy(p => p).ToList();
            do
            {
                int currnetChekedNum = primeNumHelperList[0];
                if (currnetChekedNum >= maxNumForCheckPrimeRange)
                    break;
                primeNumHelperList = primeNumHelperList.Where(p => p % currnetChekedNum != 0).ToList();
            } while (true);
            return primeNumHelperList;
        }

        public static void PrintCancatenateFormForNumber(List<int> primeNums, int number)
        {
            Console.Write(number + " = ");
            for (int i = 0; i < primeNums.Count - 1; i++)
            {
                Console.Write(primeNums[i] + " * ");
            }
            Console.Write(primeNums[primeNums.Count - 1] + " ");

            Console.WriteLine("Prime Nums Count: " + primeNums.Count);
        }
    }
}
