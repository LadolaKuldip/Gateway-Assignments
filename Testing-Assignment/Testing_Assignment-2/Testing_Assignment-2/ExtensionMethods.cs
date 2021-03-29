using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Inverts the case of letters in the string
        /// </summary>
        /// <returns>
        /// The string with inverted case
        /// </returns>
        public static string InverseCase(this string inputString)
        {
            string output = "";
            int ascii = 0;
            foreach (var ch in inputString)
            {
                ascii = (int)ch;
                if (ascii >= 65 && ascii <= 90)
                    ascii += 32;
                else if (ascii >= 97 && ascii <= 122)
                    ascii -= 32;
                output += (char)ascii;
            }
            return output;
        }

        /// <summary>
        /// Converts the string to titlecase
        /// </summary>
        /// <returns>
        /// string converted to titlecase
        /// </returns>
        public static string TitleCase(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// Converts the string to Capitalized
        /// </summary>
        /// <returns>
        /// string converted to Capitalized
        /// </returns>
        public static string Capitalized(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// Indicates whether the string provided contains all lowercase letters
        /// </summary>
        /// <returns>
        /// Success if all the characters in the string are lowercase 
        /// </returns>
        public static string CheckLower(this string inputString)
        {
            bool result = true;
            foreach (var character in inputString)
            {
                if (char.IsUpper(character))
                {
                    result = false;
                    break;
                }
                else if (char.IsLower(character))
                {
                    continue;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                return "Success";
            }
            return "Failed";
        }

        /// <summary>
        /// Indicates whether the string provided contains all uppercase letters
        /// </summary>
        /// <returns>
        /// Success if all the characters in the string are uppercase 
        /// </returns>
        public static string CheckUppar(this string inputString)
        {
            bool result = true;
            foreach (var character in inputString)
            {
                if (char.IsLower(character))
                {
                    result = false;
                    break;
                }
                else if (char.IsUpper(character))
                {
                    continue;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                return "Success";
            }
            return "Failed";
        }

        /// <summary>
        /// Indicates whether the string provided can be converted to an integer
        /// </summary>
        /// <returns>
        /// Success if the string can be converted
        /// </returns>
        public static string CheckforInt(this string inputString)
        {
            try
            {
                int x = int.Parse(inputString);
                return "Success";
            }
            catch (Exception)
            {

                return "Failed";
            }
        }

        /// <summary>
        /// Removes the last character from the given string
        /// </summary>
        /// <returns>
        /// string with its last character removed
        /// </returns>
        public static string RemoveLastChar(this string inputString)
        {
            return inputString.Substring(0, inputString.Length - 1);
        }

        /// <summary>
        /// Counts the number of words in the given string
        /// </summary>
        /// <returns>
        /// The number of words in the given string
        /// </returns>
        public static string WordCount(this string inputString)
        {
            var wordCount = 0;
            for (var i = 0; i < inputString.Length; i++)
                if (inputString[i] == ' ' || i == inputString.Length - 1)
                    wordCount++;
            return wordCount.ToString();
        }

        /// <summary>
        /// Converts the given string to an integer
        /// </summary>
        /// <returns>
        /// decimal if the given string can be converted, null otherwise
        /// </returns>
        public static string StringToInt(this string inputString)
        {
            try
            {
                return "" + int.Parse(inputString);
            }
            catch (Exception)
            {

                return "null";
            }
        }
    }
}