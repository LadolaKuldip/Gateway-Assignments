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
        /// Inverts the case of letters in the string.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String with inverted case of char.</returns>
        public static string InvertsCase(this string input)
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
        /// Converts the specified string to title case.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String with each word converted to title case</returns>
        public static string ConvertToTitleCase(this string input)
        {
            string[] stringsArray = input.Split(' ');
            string output = "";
            foreach (var item in stringsArray)
            {
                output += item.ConvertToCapitalized() + " ";
            }
            return output.Substring(0, input.Length);
        }

        /// <summary>
        /// Converts the specified string to capitalized form.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String with each word converted to capitalized form</returns>
        public static string ConvertToCapitalized(this string input)
        {
            if(input.Length >0)
            {
                char[] charArray = input.ToLower().ToCharArray();
                charArray[0] = char.ToUpper(charArray[0]);
                return new string(charArray);
            }
            return input;
        }

        /// <summary>
        /// indicates whether the string provided contains all lowercase letters.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>'Success' if all the characters in the string are lowercase</returns>
        public static string CheckForLowercase(this string input)
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
        /// indicates whether the string provided contains all uppercase letters.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>'Success' if all the characters in the string are uppercase</returns>
        public static string CheckForUpparcase(this string input)
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
        /// indicates whether the string provided can be converted to an integer
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>'Success' if the string can be converted</returns>
        public static string CheckForInteger(this string input)
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
        /// removes the last character from the given string.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>String with its last character removed</returns>
        public static string RemoveLastCharacter(this string input)
        {
            return input.Substring(0, input.Length - 1);
        }

        /// <summary>
        /// Counts the number of words in the specified string.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>The number of words in the given string</returns>
        public static string CountNoOfWords(this string input)
        {
            var wordCount = 0;
            for (var i = 0; i < input.Length; i++)
                if (input[i] == ' ' || i == input.Length - 1)
                    wordCount++;
            return wordCount.ToString(); 
        }

        /// <summary>
        /// Converts the specified string to an integer.
        /// </summary>
        /// <param name="input">String input parameter</param>
        /// <returns>decimal if the given string can be converted, null otherwise</returns>
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