using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParsreCombinators
{
    public interface IResult<out T> { T Result(IEnumerable<char> chars); }

    public interface IParser : IResult<ParserResult> { }

    public class Result
    {
        public Result(char ch, IEnumerable<char> chars)
        {
            ExceptedChar = ch;
            RemainingChars = chars;
        }

        public char ExceptedChar { get; }
        public IEnumerable<char> RemainingChars { get; }
    }

    public class ParserResult : IEnumerable<Result>
    {
        private readonly IEnumerable<Result> _data = new List<Result>();

        public ParserResult()
        {
            _data = new List<Result>();
        }

        public ParserResult(char ch, IEnumerable<char> chars)
            : this(new Result(ch, chars))
        {
        }

        public ParserResult(Result res)
        {
            _data = new List<Result>() { res };
        }


        public IEnumerator<Result> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return this.Match(
                some: (r) => $"ExceptedChar: {r.ExceptedChar}, RemainingChars: [{new Str(r.RemainingChars)}]",
                nothing: () => "Can't find char"
            );
        }
    }

    public class ExpectedChar : IParser
    {
        private readonly char _ch;
        public ExpectedChar(char ch)
        {
            _ch = ch;
        }

        public ParserResult Result(IEnumerable<char> _chars)
        {
            if (_chars.First() == _ch)
            {
                return new ParserResult(_ch, _chars.Skip(1));
            }
            else
            {
                return new ParserResult();
            }
        }

    }

    public class Chars : IEnumerable<char>
    {
        private readonly string _str;

        public Chars(string str)
        {
            _str = str;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return _str.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class OrParse : IParser
    {
        private readonly IParser _ech1;
        private readonly IParser _ech2;

        public OrParse(IParser ech1, IParser ech2)
        {
            _ech1 = ech1;
            _ech2 = ech2;
        }

        public ParserResult Result(IEnumerable<char> _chars)
        {
            var ech1Result = _ech1.Result(_chars);
            if (ech1Result.Any())
            {
                return ech1Result;
            }

            var ech2Result = _ech2.Result(_chars);
            if (ech2Result.Any())
            {
                return ech2Result;
            }
            return new ParserResult();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //var ruleB = (IRule<DmModel, DbModel>)new RuleB();

            //IDbModel dbModel = ruleB.Apply(new DmModel());

            Console.WriteLine(
                new ExpectedChar('t')
                    .Result(
                        new Chars("take")
                    )
            );

            var template = new Chars("make");
            Console.WriteLine(
                new OrParse(
                        new ExpectedChar('k'),
                        new ExpectedChar('m')
                    )
                    .Result(template)
            );

            Console.WriteLine(
                new Choise(
                    new ExpectedChar('k'),
                    new ExpectedChar('m')
                ).Result(template)
            );

            Console.WriteLine(
                new AnyOf('k', 'm')
                    .Result(template)
            );
            Console.WriteLine(
                    MyClass1.y<int>(f => n => n == 1 ? 1 : n * f(n - 1))(5)
                );
            Console.WriteLine(
                MyClass1.Fix(x => 5)
            );
        }
    }

    public class AnyOf : IParser
    {
        private readonly IEnumerable<char> _chars;
        public AnyOf(params char[] chars)
        {
            _chars = chars;
        }
        public ParserResult Result(IEnumerable<char> _templ)
        {
            return new Choise(
                _chars
                    .Select(ch => new ExpectedChar(ch))
            ).Result(_templ);
        }
    }
    public class Choise : IParser
    {
        private readonly IParser[] _parsers;

        public Choise(IEnumerable<IParser> chars)
            : this(chars.ToArray())
        {

        }
        public Choise(params IParser[] parsers)
        {
            _parsers = parsers;
        }

        public ParserResult Result(IEnumerable<char> _chars)
        {
            return _parsers
                .Aggregate((acc, next) => new OrParse(acc, next))
                .Result(_chars);
        }
    }


    public class Str
    {
        private readonly IEnumerable<char> _chars;

        public Str(IEnumerable<char> chars)
        {
            _chars = chars;
        }

        public override string ToString()
        {
            return String.Join(";", _chars);
        }
    }

    public static class Extensions
    {
        public static TOut Match<TOut>(this IEnumerable<Result> src, Func<Result, TOut> some, Func<TOut> nothing)
        {
            return src.Any() ? some(src.First()) : nothing();
        }
    }


}
