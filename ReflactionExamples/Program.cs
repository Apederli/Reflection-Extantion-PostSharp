using System;
using System.Reflection;

namespace ReflactionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            OrnekSinif ornekSinif = new OrnekSinif();

            ornekSinif.Name = "aydogan";

            Type getTypeOrnekSinif = ornekSinif.GetType();

            //Nesnenin 1 adet "Name" isimli propsunun türnü aldım
            PropertyInfo property = getTypeOrnekSinif.GetProperty("Name");

            Console.WriteLine(property);
            Console.WriteLine("////");

            //nesnenin tüm propslarının türlerini aldım
            PropertyInfo[] properties = getTypeOrnekSinif.GetProperties();

            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("////");

            //Önce Nesnenin Methodunu aldım
            MethodInfo getMethod= getTypeOrnekSinif.GetMethod("AddExtra");
            //Metottun Parametrelerine ulaşarak onları gezdim
            ParameterInfo[] methodParameters = getMethod.GetParameters();

            foreach (var item in methodParameters)
            {
                Console.WriteLine(item.DefaultValue.ToString());
            }

        }
    }



    public class OrnekSinif
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddExtra(string deger="rize", int number=53)
        {
            return $"deger:{deger} ve plaka {number}";
        }
    }





}
