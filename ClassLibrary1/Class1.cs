using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public interface ICommand { void Run(); }
    public class A : ICommand
    {
        public A(ICommand command)
        {

        }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
    public class B : ICommand
    {
        public B(ICommand command)
        {

        }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
    public class C : ICommand
    {
        public C(ICommand command)
        {

        }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public class Class1
    {
        public Class1()
        {
            var composed = new A(
                                new B(
                                    new C(null)
                                )
                            );
            //ICommand[] commands = new { new A("")}
        }
    }

    public class PChar
    {

        public PChar(char charToMatch, string str)
        {
        }
        public void Result()
        {
            new List<int>()
                .Match(
                    any: (x) => "",
                    empty: () => ""
                ).First();

        }
    }
}

public static class A
{
public static TResult Match<T, TResult>(
        this IEnumerable<T> list,
        Func<T, TResult> any,
        Func<TResult> empty
    )
{
    if (list.Any())
    {
        return any(list.First());
    } 
    else
    {
        return empty();
    }
}
}
