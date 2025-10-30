using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderTask
{
    public static class Helper
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool HasDigit(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        public static bool CheckPassword(this string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;

                if (hasUpper && hasLower && hasDigit)
                    return true;
            }

            return hasUpper && hasLower && hasDigit;
        }

        public static string Capitalize(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (text.Length == 1)
                return text.ToUpper();

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        public static string CustomSubstring(this string text, int startIndex)
        {
            if (text == null)
                return "";

            string result = "";
            for (int i = startIndex; i < text.Length; i++)
            {
                result += text[i];
            }
            return result;
        }
        public static string CustomSubstring(this string text, int startIndex, int length)
        {
            if (text == null)
                return "";

            string result = "";
            for (int i = startIndex; i < startIndex + length && i < text.Length; i++)
            {
                result += text[i];
            }
            return result;
        }
        public static bool CustomContains(this string text, string value)
        {
            if (text == null || value == null)
                return false;

            if (value == "")
                return true;

            for (int i = 0; i <= text.Length - value.Length; i++)
            {
                int j = 0;
                while (j < value.Length && text[i + j] == value[j])
                {
                    j++;
                }

                if (j == value.Length)
                    return true;
            }

            return false;
        }

    }
}
