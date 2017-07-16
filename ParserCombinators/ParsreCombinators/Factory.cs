using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsreCombinators
{
    //public class Factory<T1,T2>
    //{
    //    public Factory(IHasConstructor<T1, T2> classInstance)
    //    {

    //    }

    //    public Factory<T2> With(T1 p1)
    //    {
    //        return new Factory<T2>();
    //    }
    //}


    public class Factory<T1>
    {
        public Factory(IHasConstructor<T1> classInstance)
        {

        }

    }

    public abstract class IHasConstructor<T1, T2>
        where T1 : class
        where T2 : class
    {
        protected IHasConstructor(T1 p1, T2 p2) { }
    }

    public abstract class IHasConstructor<T1>
    {
        protected IHasConstructor(T1 p1) { }
    }

    public interface ICtrParams<T1, T2> { }
    public class MyClass : ICtrParams<int, int> 
    {
        
    }
}
