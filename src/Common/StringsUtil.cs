using System;
using System.Linq;
using System.Text;

namespace IntrepidProducts.Common
{
    public static class StringsUtil
    {
        public static string? ToLowerSnakeCase(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return text
                .Trim()
                .Replace(' ', '_')
                .ToLower();
        }

        public static string ReverseAndNot(int nbr)
        {
            var nbrArray = nbr.ToString().ToCharArray();

            var nbrArrayReversed = nbrArray.Reverse();

            StringBuilder builder = new StringBuilder(nbrArray.Length * 2);

            foreach (var c in nbrArrayReversed)
            {
                builder.Append(c);
            }

            foreach (var c in nbrArray)
            {
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string ReverseOrderOfWords(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            var words = text.Split(' ').Reverse();

            var results = String.Empty;

            foreach (var word in words)
            {
                results = results + " " + word;
            }

            return results.TrimStart();
        }

        public static bool IsPalindrome(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return (text.ToLower() == ReverseOrderOfWords(text).ToLower());
        }

        /// <summary>
        /// Based on https://edabit.com/challenge/RFeBL2TzSf7mRMNJi
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Maskify(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (text.Length < 5)
            {
                return text;
            }

            var lastFourCharsIndex = text.Length - 4;
            var lastFourChars = text.Substring(lastFourCharsIndex, 4);
            var maskedText = string.Empty;


            for (int i = 0; i < lastFourCharsIndex; i++)
            {
                maskedText = maskedText + "*";
            }

            return maskedText + lastFourChars;
        }
    }
}