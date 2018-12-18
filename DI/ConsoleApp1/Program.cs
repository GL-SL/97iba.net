using System;
using System.Reflection;

namespace ConsoleApp1
{
    // vICTIM
    public interface Abi79
    {
        void Kin();
    }

    public abstract class Riba : Abi79
    {
        private int boob = 5;
        public abstract void Kin();
        public virtual void Inoukin()
        {
            Console.WriteLine("Te3bas");
        }
    }
 
    public class Antar : Riba
    {
        public sealed override void Kin()
        {
         
            if((GetType().Name == nameof(Antar)))
                Console.WriteLine(GetType().Name + " Ken " + GetType().BaseType.Name);
            else Console.WriteLine("Yitfarej");
        }

        public override void Inoukin()
        {
            Console.WriteLine(GetType().Name+" Ken "+ GetType().BaseType.Name);
        }

    }
    public class Sami : Antar
    {
        //public override void Kin()
        //{
        //    Console.WriteLine(GetType().Name + " Netfarej fi " + GetType().BaseType.Name);
        //    base.Kin();
        //}
        public override void Inoukin()
        {
            Console.WriteLine(GetType().Name + " Netfarej fi " + GetType().BaseType.Name);
            base.Kin();
        }
    }

    public class Bonou : Sami
    {
        public sealed override void Inoukin()
        {
            Console.WriteLine(GetType().Name + " Mouhkini li lok " + GetType().BaseType.Name);
            base.Kin();
        }
    }

    public class Soleil
    {
        public virtual void Kin(object victim)
        {
            try
            {
                var t = victim.GetType();
                var cerise = t.GetField("boob");
                var delice = cerise.GetValue(victim);
                Console.WriteLine(GetType().Name + " chrab " + delice + " litrat delice");
                cerise.SetValue(victim, 0);
            }
            catch
            {

                Console.WriteLine("L7lib ma9tou3 fi janvier");
            }
        }
    }

    public class SormNucleaire : Soleil
    {
        Type Jibliel9a7ba(Type t)
        {
            try
            {
               
                var cerise = t.GetField("boob",  BindingFlags.NonPublic | BindingFlags.Instance);
                if(cerise == null)
                    return Jibliel9a7ba(t.BaseType);

                return t;
            }
            catch
            {

                if (t.BaseType == typeof(Abi79))
                    return null;
                else return Jibliel9a7ba(t.BaseType);
            }
        }
        public override void Kin(object victim)
        {
            try
            {
                var t = Jibliel9a7ba(victim.GetType());
                var cerise = t.GetField("boob", BindingFlags.NonPublic | BindingFlags.Instance);

                var delice = cerise.GetValue(victim);
                Console.WriteLine(GetType().Name + " chrab " + delice + " litrat delice");
                cerise.SetValue(victim, 0);
            }
            catch
            {

                Console.WriteLine("L7lib ma9tou3 fi janvier");
            }
        }
    }
    class Arsslen
    {
        static void Main(string[] args)
        {
            var s = new Sami();
            var a = new Antar();
            var b = new Bonou();
            var c = new Soleil();
            var sn = new SormNucleaire();
            Console.WriteLine("************Antar****************");
            a.Kin();
            Console.WriteLine("************Sami****************");
            s.Kin();
            Console.WriteLine("************Bonou****************");
            b.Kin();


            Console.WriteLine("************Antar2****************");
            a.Inoukin();
            Console.WriteLine("************Sami2****************");
            s.Inoukin();
            Console.WriteLine("************Bonou2****************");
            b.Inoukin();

            Console.WriteLine("************Soleil d5al****************");
            c.Kin(a);
            c.Kin(s);
            c.Kin(b);
            c.Kin(a);

            Console.WriteLine("************Soleil Nucleaire d5al****************");
            sn.Kin(a);
            sn.Kin(s);
            sn.Kin(b);
            sn.Kin(a);
            Console.Read();
        }
    }
}
