using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmApi.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string pWord)
        {
            if (pWord == null)
                return null;

            if (string.IsNullOrEmpty(pWord))
                return string.Empty;

            if (pWord.Length == 1)
                return pWord.ToUpper();

            return pWord.Substring(0, 1).ToUpper() + pWord.Substring(1, pWord.Length - 1);
        }

        public static string Decapitalize(this string pWord)
        {
            if (pWord == null)
                return null;

            if (string.IsNullOrEmpty(pWord))
                return string.Empty;

            if (pWord.Length == 1)
                return pWord.ToLower();

            return pWord.Substring(0, 1).ToLower() + pWord.Substring(1, pWord.Length - 1);
        }
    }
}
