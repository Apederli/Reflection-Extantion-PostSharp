using MoreLinq;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharpExampl
{
    class Program
    {
        static void Main(string[] args)
        {
            Job job = new Job();

            job.AddPropsValue();

            job.GetParameters("53", "rize");



            //hastane hh = new hastane();

            //hh.changeName();

            Console.ReadLine();
        }
    }

    [Serializable]
    public class TestAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {

            if (args.Arguments[0] == "")
            {
                Console.WriteLine("test");
            }

            base.OnInvoke(args);
        }
    }


    [Serializable]
    public class ChangeCityAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {

            ParameterInfo[] parameters = args.Method.GetParameters();


            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];

                Console.WriteLine(parameter.Name);

                Console.WriteLine(args.Arguments.GetArgument(i));

                args.Arguments.SetArgument(i, "Aydoğan");


                //if (parameter.Name == "city" && args.Arguments.GetArgument(i).Equals("rize"))
                //{
                //    args.Arguments.SetArgument(i, "Aydoğan");
                //}
            }

            List<object> GetObjects = new List<object>();

            for (int i = 0; i < parameters.Length; i++)
            {
                GetObjects.Add(args.Arguments.GetArgument(i));
            }

            var test = GetObjects;


            base.OnInvoke(args);
        }
    }



    [AttributeUsage(AttributeTargets.Method)]
    [Serializable]
    public class Aspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {


            Console.WriteLine("Methoda Girdiğinde");

            ParameterInfo[] parameters = args.Method.GetParameters();


            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];

                Console.WriteLine(parameter.Name);

                Console.WriteLine(args.Arguments.GetArgument(i));

                if (parameter.Name == "city" && args.Arguments.GetArgument(i).Equals("rize"))
                {
                    args.Arguments.SetArgument(i, "Aydoğan");
                }
            }

        }

        //public override void OnExit(MethodExecutionArgs args)
        //{
        //    Console.WriteLine("Metottn çıktığında");
        //}
    }

    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public void AddPropsValue()
        {
            Id = 5;
            Name = "Acibadem";
            Console.WriteLine($"Id : {Id} Name : {Name} ");
        }

        [TestAspect]
        public void AddPropsValue2()
        {
            Id = 4;
            Name = "Acibadem";
            Console.WriteLine($"Id : {Id} Name : {Name} ");
        }

        [ChangeCityAspect]
        public void GetParameters(string plate, string city)
        {
            Console.WriteLine($"Yeni gelen: {plate}");
            Console.WriteLine($"Yeni gelen: {city}");
        }

    }
}
