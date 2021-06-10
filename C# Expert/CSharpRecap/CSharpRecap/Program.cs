using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================== Task 1 : list of countries ==================== " + Environment.NewLine);
            CountriesMethods.Exicute();
            Console.WriteLine(Environment.NewLine + "==================== Task 2 : Dynamic Properties ==================== " + Environment.NewLine);
            StudentDynamic.Exicute();
            Console.WriteLine(Environment.NewLine + "==================== Task 3 : Example of Delegate ==================== " + Environment.NewLine);
            DelegateFeature.Caller();
            Console.ReadLine();
        }

    }

    public class CountriesMethods
    {
        public static void Exicute()
        {
            List<string> countries = HelperMethods.GetCountry();
            // Console.WriteLine("All Countries:" + Environment.NewLine + String.Join(",", countries) + Environment.NewLine);

            // List<string> countriesStartWithI = countries.FindAll(c => c.StartsWith('I'));

            int countriesStartWithI = countries.Count(c => c.StartsWith('I'));
            Console.WriteLine("========== Countries Strat with I: ==========");
            Console.WriteLine("Total Countries :  " + countriesStartWithI + Environment.NewLine);

            Console.WriteLine("========== Countries Grouped By Length: ==========");

            var countriesGroupedByLength = countries.GroupBy(c => c.Length).OrderBy(c => c.Key);
            foreach (var countryGroup in countriesGroupedByLength)
            {
                Console.WriteLine(Environment.NewLine +"Name Length : "+countryGroup.Key + ":");
                Console.WriteLine(String.Join(",", countryGroup));
            }
        }
    }
    
    public class StudentDynamic
    {
        public static void Exicute()
        {
            SchoolStudent schoolStudent = new SchoolStudent(1, "Kuldip","Ladola",21,true,true, true,DateTime.Now,"Rajkot");
            CollegeStudent collegeStudent = new CollegeStudent();

            HelperMethods.CopyStudent(schoolStudent, collegeStudent);

            var schoolStudentProperties = schoolStudent.GetType().GetProperties();
            var collegeStudentProperties = collegeStudent.GetType().GetProperties();

            Console.WriteLine(Environment.NewLine + "========== School Student Object: ==========" + Environment.NewLine);

            foreach (var ssProperty in schoolStudentProperties)
            {
                Console.WriteLine("{0} : {1}", ssProperty.Name, ssProperty.GetValue(schoolStudent));
            }

            Console.WriteLine(Environment.NewLine + "========== College Student Object: ==========" + Environment.NewLine);

            foreach (var csProperty in collegeStudentProperties)
            {
                Console.WriteLine("{0} : {1}", csProperty.Name, csProperty.GetValue(collegeStudent));
            }
        }

    }

    public class DelegateFeature
    {
        public delegate void BuyItem(int amount, int charge);

        static void AddGst(int amount, int charge)
        {
            Console.WriteLine("Gst Charge: " + (amount + (amount*charge/100)));
        }
        static void AddService(int amount, int charge)
        {
            Console.WriteLine("Service Charge : " + (amount + (amount * charge / 100)));
        }
        static void AddGoods(int amount, int charge)
        {
            Console.WriteLine("Goods Charge : " + (amount + (amount * charge / 100)));
        }
        static void AddDelivery(int amount, int charge)
        {
            Console.WriteLine("Delivery Charge : " + (amount + (amount * charge / 100)));
        }

        public static void Perform_Calculation(BuyItem newItem)
        {
            int amount = 10, charge = 5;

            newItem(amount, charge);
        }

        public static void Caller()
        {
            BuyItem newItem = AddGst;

            newItem += AddGoods;
            newItem += AddDelivery;
            newItem += AddService;

            Console.WriteLine(Environment.NewLine + "========== Including All Charges : ==========");
            Perform_Calculation(newItem);

            newItem -= AddDelivery;
            Console.WriteLine(Environment.NewLine + "========== Free Delivery: ==========");
            Perform_Calculation(newItem);
        }
    }

    public class HelperMethods
    {
        public static List<string> GetCountry()
        {
            List<string> list = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo info in cultures)
            {
                RegionInfo info2 = new RegionInfo(info.LCID);
                if (!list.Contains(info2.EnglishName))
                {
                    list.Add(info2.EnglishName);
                }
            }
            return list;
        }

        public static void CopyStudent(SchoolStudent sourse, CollegeStudent destination)
        {
            var sourseProperties = sourse.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sProperty in sourseProperties)
            {
                foreach (var dProperty in destinationProperties)
                {
                    if (sProperty.Name == dProperty.Name && sProperty.PropertyType == dProperty.PropertyType)
                    {
                        dProperty.SetValue(destination, sProperty.GetValue(sourse));
                        break;
                    }
                }
            }
        }
    }
}