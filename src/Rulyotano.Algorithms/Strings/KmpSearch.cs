using System.Collections.Generic;

namespace Rulyotano.Algorithms.Strings
{
    public static class KmpSearch
    {
        private const int NotFoundValue = -1;

        public static int SearchFirstOccurrence(this string text, string s)
        {
            if (string.IsNullOrEmpty(text) 
                || string.IsNullOrEmpty(s)
                || text.Length < s.Length)
                return NotFoundValue;

            var lpf = KmpLps.CalcualteLps(s);
            var i = 0;
            var si = 0;
            while (i < text.Length)
            {
                if (text[i] == s[si])
                {
                    if (si == s.Length - 1)
                        return i - si;
                    i++;
                    si++;
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

            return NotFoundValue;
        }

        public static IEnumerable<int> SearchAllOccurrences(this string text, string s)
        {
            if (string.IsNullOrEmpty(text) 
                || string.IsNullOrEmpty(s)
                || text.Length < s.Length)
                yield break;

            var lpf = KmpLps.CalcualteLps(s);
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
