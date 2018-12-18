using System;
using System.Reflection;
using Reflection.Core;

namespace Reflection
{
    [Selector(NickName = "Ass")]
    class A
    {

    }

    class B
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            // get executing assembly types
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                    Console.WriteLine(type.Name);
            }
            //Console.WriteLine("******************");
            //// get all loaded types
            //foreach (var referencedAssembly in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    Console.WriteLine("******************"+referencedAssembly.FullName);
            //    foreach (var type in referencedAssembly.GetTypes())
            //    {
            //        Console.WriteLine(type.Name);
            //    }
            //}


            Console.WriteLine("----------------------");
            // get all loaded types that has selector attribute
            //foreach (var referencedAssembly in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    Console.WriteLine("******************" + referencedAssembly.FullName);
            //    foreach (var type in referencedAssembly.GetTypes())
            //    {
            //        var ca = type.GetCustomAttribute<SelectorAttribute>();
            //        if(ca != null)
            //         Console.WriteLine(type.Name + " its nickname is " + ca.NickName);
            //    }
            //}

            var c = new C();
            Validate(c);
            c.Value = "S";
            Validate(c);
            Console.Read();
        }

       static void Validate(object x)
        {
            foreach (var propertyInfo in x.GetType().GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(x);
                var lezemAttribute = propertyInfo.GetCustomAttribute<LezemAttribute>();
                if (lezemAttribute != null && propertyValue == null)
                {
                    Console.WriteLine("Property " + propertyInfo.Name + " is required");
                }
            }
        }
    }
}
