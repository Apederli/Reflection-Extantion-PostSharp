﻿
using MoreLinq.Extensions;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string deger = "pederli";

            

            Console.WriteLine(deger.AddString());



            Reflect reflect = new Reflect();

            Type type = typeof(Reflect);
            Type type2 = reflect.GetType();

            //PropertyInfo[] test = type.GetProperties();

            //foreach (PropertyInfo item in test)
            //{
            //    Console.WriteLine($"parametre adı : {item.Name} type : {item.GetType()}");
            //    Console.ReadLine();
            //}
            //Console.ReadLine();


            MethodInfo method = type.GetMethod("GetCity");


            ParameterInfo[] parameters = method.GetParameters();

            parameters.ForEach(item =>
            {
                Console.WriteLine($"parametre Name : {item.Name} {(item.HasDefaultValue ? item.DefaultValue : null)} ");
            });




            OrnekReflection reflaction = new OrnekReflection();

            Type typeReflection = reflaction.GetType();

            var properties = typeReflection.GetProperties();

            properties.ForEach(x =>
            {
                Console.WriteLine(x.Name);
            });

        }
    }

    public class Reflect
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string GetCity(string city = "istanbul", int plate = 34)
        {
            return $"{city} {plate}";
        }

    }



    public static class StringExtension
    {
        public static string StringEx(this string str)
        {
            //return "TC " + str;
            return $"TC {str}";

        }

        public static string StringEx2(string str)
        {
            //return "TC " + str;
            return $"TC {str}";

        }

    }


    public static class DateTimeExtension
    {
        public static string DateEx(this DateTime dateTime)
        {


            return dateTime.ToString("dd MM yyyy HH:mm: ss.ff");
        }
    }

    public static class Kdv
    {
        public static double AddKdv(this double price)
        {
            price += price * (0.08);

            return price;
        }
    }


    public static class OrnekExtantion
    {
        public static string AddString(this string additional)
        {
            return $"Tc {additional}";
        }
    }

    public  class OrnekReflection
    {
        public DateTime DateTime { get; set; }
        
        public string Surname { get; set; }

    }




































}