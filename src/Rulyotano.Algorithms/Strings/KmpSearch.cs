using System.Collections.Generic;

namespace Rulyotano.Algorithms.Strings
{
    public static class KmpSearch
    {
        private const int NotFoundValue = -1;

        /// <summary>
        /// Search for the first occurrence of "s" in "text" using Kmp algorithm O(n+m)
        /// </summary>
        /// <param name="text">Text where search for the first "s" occurrence</param>
        /// <param name="s">String to search in "text"</param>
        /// <returns>First occurence index or NotFound = -1</returns>
        public static int SearchFirstOccurrence(this string text, string s)
        {
            using var allOccurrencesEnumerator = SearchAllOccurrences(text, s).GetEnumerator();

            return allOccurrencesEnumerator.MoveNext() ? allOccurrencesEnumerator.Current : NotFoundValue;
        }

        /// <summary>
        /// Search for all the occurrences of "s" in "text" using Kmp algorithm O(n+m)
        /// </summary>
        /// <param name="text">Text where search for the all "s" occurrences</param>
        /// <param name="s">String to search in "text"</param>
        /// <returns>Enumerable of indexes where match is found. Empty if there is no occurrences</returns>
        public static IEnumerable<int> SearchAllOccurrences(this string text, string s)
        {
            if (string.IsNullOrEmpty(text) 
                || string.IsNullOrEmpty(s)
                || text.Length < s.Length)
                yield break;

            var lpf = KmpLps.CalculateLps(s);
            var i = 0;
            var si = 0;
            while (i < text.Length)
            {
                if (text[i] == s[si])
                {
                    if (si == s.Length - 1)
                    {
                        yield return i - si;
                        si = lpf[si]; 
                    }
                    else
                    {
                        si++;
                    }
                    i++;
                }
                else if (si == 0)
                {
                    i++;
                }
                else
                {
                    si = lpf[si - 1];
                }
            }
        }
    }
}
