using System;
using System.Collections.Generic;
using System.Text;

namespace Rulyotano.Algorithms.Strings
{
    public static class KmpSearch
    {
        private const int NotFoundValue = -1;

        public static int SearchFirstOccurence(this string text, string s)
        {
            if (string.IsNullOrEmpty(text) 
                || string.IsNullOrEmpty(s)
                || text.Length < s.Length)
                return NotFoundValue;

            var i = 0;
            while (i < text.Length)
            {
                var si = 0;
                while (si < s.Length)
                {
                    if (i + si >= text.Length || text[i + si] != s[si])
                        break;
                    si++;
                }

                if (si == s.Length)
                    return i;
                i++;
            }

            return NotFoundValue;
        }
    }
}
