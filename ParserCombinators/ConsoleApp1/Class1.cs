using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IContent<T> { T Content(); } 

    public class NthNumberOfSybols : IEnumerable<char>
    {
        private readonly char _symbol;
        private readonly int _n;
        public NthNumberOfSybols(int N, char symbol)
        {
            _symbol = symbol;
            _n = N;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return Enumerable
                    .Range(1, _n)
                    .Select(i => _symbol)
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NLineHalfPyramid : IEnumerable<char>
    {
        private readonly char _symbol;
        private readonly int _pyramidHeight;
        private readonly int _n;
        private readonly char _whiteSpace = ' ';
        public NLineHalfPyramid(int N, int pyramidHeight, char symbol)
        {
            _symbol = symbol;
            _n = N;
            _pyramidHeight = pyramidHeight;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return new CombinedSymbols(
                       new NthNumberOfSybols(_pyramidHeight - _n, _whiteSpace),
                       new NthNumberOfSybols(_n, _symbol)
                   ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CombinedSymbols : IEnumerable<char>
    {
        private readonly IEnumerable<char> _first;
        private readonly IEnumerable<char> _second;
        public CombinedSymbols(
                 IEnumerable<char> first,
                 IEnumerable<char> second
            )
        {
            _first = first;
            _second = second;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return _first
                    .Concat(_second)
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class HalfPyramid : IEnumerable<IEnumerable<char>>
    {
        private readonly int _pyramidHeight;
        private readonly char _symbol;
        public HalfPyramid(int pyramidHeight, char symbol)
        {
            _pyramidHeight = pyramidHeight;
            _symbol = symbol;
        }
        public IEnumerator<IEnumerable<char>> GetEnumerator()
        {
            return Enumerable
                    .Range(1, _pyramidHeight)
                    .Select(n => new NLineHalfPyramid(n, _pyramidHeight, _symbol))
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ResultView 
    {
        private readonly IEnumerable<IEnumerable<char>> _halfPyramid;
        public ResultView(IEnumerable<IEnumerable<char>> halfPyramid)
        {
            _halfPyramid = halfPyramid;
        }
        public override string ToString()
        {
            return
                new JoinedSymbols(
                    _halfPyramid.Select(hpl => new JoinedSymbols(hpl, String.Empty).Content()),
                    Environment.NewLine
                ).Content();
        }
    }

    public class JoinedSymbols: IContent<string>
    {
        private readonly IEnumerable<string> _symbols;
        private readonly string _separator;

        public JoinedSymbols(IEnumerable<char> symbols)
            : this(new SymbolsAsStrings(symbols)) {}
        public JoinedSymbols(IEnumerable<char> symbols, string separator)
            : this(new SymbolsAsStrings(symbols), separator) {}
        public JoinedSymbols(IEnumerable<string> symbols)
            : this(symbols, String.Empty) {}
        public JoinedSymbols(IEnumerable<string> symbols, string separator)
        {
            _symbols = symbols;
            _separator = separator;
        }
        public string Content()
        {
            return String.Join(_separator, _symbols);
        }
    }

    public class SymbolsAsStrings : IEnumerable<string>
    {
        private readonly IEnumerable<char> _symbols;
        public SymbolsAsStrings(IEnumerable<char> symbols)
        {
            _symbols = symbols;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _symbols
                    .Select(s => s.ToString())
                    .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
