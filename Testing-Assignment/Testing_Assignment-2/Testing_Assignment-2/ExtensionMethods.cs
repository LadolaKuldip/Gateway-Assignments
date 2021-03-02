using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    public class ExtensionMethods
    {
            public static string StringConvert(string inputString, string operation)
            {
                string output = "";
                int ascii = 0;
                if (operation.Equals("UppartoLower"))
                {
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
                else if (operation.Equals("TitleCase") || operation.Equals("Capitalized"))
                {
                    TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
                    return textInfo.ToTitleCase(inputString);
                }

                else if (operation.Equals("CheckLower"))
                {
                    foreach (var item in inputString)
                    {
                        ascii = (int)item;
                        bool status = false;
                        if (ascii >= 97 && ascii <= 122)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                        if (status)
                        {
                            return "lowerCase";
                        }
                    }
                }
                else if (operation.Equals("CheckUppar"))
                {
                    foreach (var item in inputString)
                    {
                        ascii = (int)item;
                        bool status = false;
                        if (ascii >= 65 && ascii <= 90)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                        if (status)
                        {
                            return "upparCase";
                        }
                    }
                }
                else if (operation.Equals("CheckforInt"))
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
                else if (operation.Equals("RemoveLastChar"))
                {
                    return inputString.Substring(inputString.Length - 1);
                }
                else if (operation.Equals("WordCount"))
                {
                    return "" + inputString.Count();
                }
                else if (operation.Equals("StringToInt"))
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
                return "";
            }
        }
    }