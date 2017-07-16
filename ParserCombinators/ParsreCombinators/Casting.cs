using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsreCombinators
{

    public interface IDbModel {}
    public interface IDmModel {}

    public class DbModel : IDbModel {}
    public class DmModel : IDmModel {}
    public class Middle { }

    public interface IRule { }
    public interface IRule<in TInput, out TOutput> : IRule
        where TInput : IDmModel
        where TOutput : IDbModel
    {
        TOutput Apply(TInput elem);
    }


    public abstract class Rule<TDmModel, TMiddle, TDb> : IRule<TDmModel, TDb>
        where TDmModel : IDmModel
        where TDb : IDbModel
    {
        private readonly Func<TDmModel, TMiddle> _rule;
        protected Rule(Func<TDmModel, TMiddle> rule)
        {
            _rule = rule;
        }
        protected abstract TDb Apply(TMiddle transformedMessage);
        public TDb Apply(TDmModel elem)
        {
            throw new NotImplementedException();
        }
    }


    public class RuleA : Rule<IDmModel, Middle, IDbModel>
    {
        public RuleA(Func<IDmModel, Middle> rule) : base(rule)
        {
        }

        protected override IDbModel Apply(Middle transformedMessage)
        {
            throw new NotImplementedException();
        }
    }

    public class RuleB : RuleA
    {
        public RuleB() : base((dm) => new Middle()) {}
    }
}
