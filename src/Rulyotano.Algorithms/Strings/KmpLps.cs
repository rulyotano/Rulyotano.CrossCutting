using System;

namespace Rulyotano.Algorithms.Strings
{
    /// <summary>
    /// Longest Prefix Suffix
    /// </summary>
    public static class KmpLps
    {
        /// <summary>
        /// Calculate the Longest Prefix Suffix array for a string.
        /// Each position i in the resulting array will be the size of the longest prefix, that is a suffix at that position.
        /// For example:
        /// for "abcdabcxabcd" the returning array will be [0,0,0,0,1,2,3,0,1,2,3,4]
        /// note that at position 6 we have a 3. The string up to that index is "abcdabc..."
        /// note that the ending of the string is "...abc" which is equal to the start of "abcd..."
        /// </summary>
        /// <param name="s">String to calculate the LPS</param>
        /// <returns>Lps array</returns>
        public static int[] CalculateLps(string s)
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