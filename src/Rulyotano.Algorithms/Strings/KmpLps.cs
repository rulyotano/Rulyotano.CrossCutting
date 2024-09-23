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
                    lps[i] = prevLpsIndex + 1;
                    prevLpsIndex++;
                    i++;
                } 
                else if (prevLpsIndex == 0)
                {
                    lps[i] = 0;
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
 
a b c
0 0 0
p i 
 */
