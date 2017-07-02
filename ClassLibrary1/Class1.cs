using System;

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

        }
    }
}
