using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW4
{
    static class ReflectorsConstants
    {
        static string reflectorCStart = "ABCDEGHKLMNTSFVPJIOYRZXWQU",
                      reflectorCEnd   = "FVPJIOYRZXWQUABCDEGHKLMNTS";

        public static Dictionary<char, char> reflectorC;
        static ReflectorsConstants()
        {
            reflectorC = reflectorCStart.Zip(reflectorCEnd, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
