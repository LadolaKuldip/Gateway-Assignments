﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpRecap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Task 1 : list of countries ========== " + Environment.NewLine);
            CountriesMethods.Exicute();
            Console.WriteLine(Environment.NewLine + "========== Task 2 : Dynamic Properties ========== " + Environment.NewLine);
            StudentDynamic.Exicute();
            Console.WriteLine(Environment.NewLine + "========== Task 3 : Example of Delegate ========== " + Environment.NewLine);
            DelegateFeature.Caller();
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
            Console.WriteLine("Countries Strat with I:" + countriesStartWithI + Environment.NewLine);

            Console.WriteLine("Countries Grouped By Length:");

            var countriesGroupedByLength = countries.GroupBy(c => c.Length).OrderBy(c => c.Key);
            foreach (var countryGroup in countriesGroupedByLength)
            {
                Console.WriteLine(Environment.NewLine +"Name Length : "+countryGroup.Key + ":");
                Console.WriteLine(String.Join(",", countryGroup));
            }
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
    }

    public class StudentDynamic
    {
        public static void Exicute()
        {
            SchoolStudent schoolStudentObject = new SchoolStudent(1, "Kuldip");
            var schoolStudentObjectProperties = schoolStudentObject.GetType().GetProperties().Select(m => new
            {
                PropName = m.Name,
                PropValue = m.GetValue(schoolStudentObject)
            });

            Console.WriteLine("School Property Names: " + string.Join(",", schoolStudentObjectProperties.Select(m => m.PropName)));
            Console.WriteLine("School Property Values: " + string.Join(",", schoolStudentObjectProperties.Select(m => m.PropValue)));


            CollegeStudent collegeStudentObject = new CollegeStudent();
            var propInfo = schoolStudentObject.GetType().GetProperties();
            foreach (var item in propInfo)
            {
                collegeStudentObject.GetType().GetProperty(item.Name).SetValue(collegeStudentObject, item.GetValue(schoolStudentObject));
            }
            var collegeStudentObjectProperties = collegeStudentObject.GetType().GetProperties().Select(m => new
            {
                PropName = m.Name,
                PropValue = m.GetValue(collegeStudentObject)
            });

            Console.WriteLine("College Property Names: " + string.Join(",", collegeStudentObjectProperties.Select(m => m.PropName)));
            Console.WriteLine("College Property Values: " + string.Join(",", collegeStudentObjectProperties.Select(m => m.PropValue)));
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

        public static void Caller()
        {
            BuyItem newItem = AddGst;

            newItem += AddGoods;
            newItem += AddDelivery;
            newItem += AddService;

            Console.WriteLine(Environment.NewLine + "Including All Charges : ");
            Perform_Calculation(newItem);

            newItem -= AddDelivery;
            Console.WriteLine(Environment.NewLine + "Free Delivery:");
            Perform_Calculation(newItem);
        }

        public static void Perform_Calculation(BuyItem newItem)
        {
            int amount = 10, charge = 5;

            newItem(amount, charge);
        }

    }
}