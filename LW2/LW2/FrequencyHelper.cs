using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW2
{
    class FrequencyHelper
    {
        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static public void CalculateFrequency(string message)
        {
            foreach (char character in alphabet)
            {
                Console.WriteLine(character.ToString() + " : " + (double)message.Count(p=>p==character)/(double)message.Length);
            }
        }
            
            
    }
}
