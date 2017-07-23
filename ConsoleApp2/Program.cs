using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public interface IEmailAdress : IEnumerable<string> { }

    public sealed class ContactInfo : Union<EmailContactInfo, PostalContactInfo>
    {
        public ContactInfo(EmailContactInfo t1) : base(t1)
        {
        }

        public ContactInfo(PostalContactInfo t2) : base(t2)
        {
        }
    }

    public class EmailContactInfo 
    {
        private readonly string _name;
        public EmailContactInfo(string name)
        {
            _name = name;
        }
        public string Name()
        {
            return _name;
        }
    }

    public class PostalContactInfo
    {
        private readonly int _number;
        public PostalContactInfo(int number)
        {
            _number = number;
        }

        public int Number()
        {
            return _number;
        }
    }

    public abstract class Union<T1, T2>
        where T1 : class
        where T2 : class
    {
        private readonly T1 _t1;
        private readonly T2 _t2;

        public Union(T1 t1) : this(t1, null) { }
        public Union(T2 t2) : this(null, t2) { }
        private Union(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }
        public TResult Match<TResult>(
                Func<T1, TResult> t1,
                Func<T2, TResult> t2
            )
        {
            if (_t1 != null)
            {
                return t1(_t1);
            }
            else if (_t2 != null)
            {
                return t2(_t2);
            }

            throw new Exception("");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ContactInfo ci = new ContactInfo(new EmailContactInfo("gioo"));
            ci = new ContactInfo(new PostalContactInfo(1));

            var r = ci.Match(
                (t1) => t1.Name(),
                (t2) => t2.Number().ToString()
            );
            Console.WriteLine(r);
            Console.ReadLine();
        }
    }
}
