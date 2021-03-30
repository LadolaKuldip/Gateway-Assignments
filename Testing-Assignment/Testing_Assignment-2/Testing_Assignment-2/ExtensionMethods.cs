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
        public static string ChangeCase(this string input)
        {
            string output = "";
            int ascii = 0;
            foreach (var ch in input)
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
        public static string ConvertTitleCase(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        /// Converts the string to Capitalized
        /// </summary>
        /// <returns>
        /// string converted to Capitalized
        /// </returns>
        public static string ConvertCapitalized(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());            
        }

        /// <summary>
        /// Indicates whether the string provided contains all lowercase letters
        /// </summary>
        /// <returns>
        /// Success if all the characters in the string are lowercase 
        /// </returns>
        public static string CheckForLower(this string input)
        {
            bool result = true;
            foreach (var character in input)
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
        public static string CheckForUppar(this string input)
        {
            bool result = true;
            foreach (var character in input)
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
        public static string CheckforInt(this string input)
        {
            try
            {
                int x = int.Parse(input);
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
        public static string RemoveLastChar(this string input)
        {
            return input.Substring(0, input.Length - 1);
        }

        /// <summary>
        /// Counts the number of words in the given string
        /// </summary>
        /// <returns>
        /// The number of words in the given string
        /// </returns>
        public static string WordCount(this string input)
        {
            var wordCount = 0;
            for (var i = 0; i < input.Length; i++)
                if (input[i] == ' ' || i == input.Length - 1)
                    wordCount++;
            return wordCount.ToString();
        }

        /// <summary>
        /// Converts the given string to an integer
        /// </summary>
        /// <returns>
        /// decimal if the given string can be converted, null otherwise
        /// </returns>
        public static string StringToInt(this string input)
        {
            try
            {
                return "" + int.Parse(input);
            }
            catch (Exception)
            {

                return "null";
            }
        }
    }
}