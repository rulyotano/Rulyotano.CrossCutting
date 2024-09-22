using System;

namespace Rulyotano.Algorithms.Strings
{
    /// <summary>
    /// Longest Prefix Sufix
    /// </summary>
    public static class KmpLps
    {
        public static int[] CalcualteLps(string s)
        {
            if (s == null)
                return Array.Empty<int>();
            var lps = new int[s.Length];

            var prevLpsIndex = 0;
            var i = 1;

            while (i < s.Length)
            {
                if (s[i] == s[prevLpsIndex])
                {
                    lps[i] = lps[prevLpsIndex] + 1;
                    prevLpsIndex++;
                    i++;
                } 
                else if (s[prevLpsIndex] == 0)
                {
                    lps[i] = 0;
                    prevLpsIndex = 0;
                    i++;
                }
                else
                {
                    prevLpsIndex = lps[prevLpsIndex-1];
                }
            }

            return lps;
        }
    }
}

/*
 
A A A A X A
0 1 2 3 0 0
    p   i 
 */
