using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParsreCombinators
{
    public static class MyClass1
    {
        public static Func<T, T> y<T>(Func<Func<T, T>, Func<T, T>> f)
        {
            return f(x => y(f)(x));
        }

        public static int Const42(int x)
        {
            return 42;
        }

        public static int Fix(Func<int, int> f)
        {
            return f(Fix(f));
        }

        //public static T F<T>(Func<T, T> f)
        //{
        //    Func<T, Func<T, T>> ff = arg => f;
        //    return f(f);
        //}
    }
}
