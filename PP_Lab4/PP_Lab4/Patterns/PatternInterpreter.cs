using System.Collections.Generic;

namespace PP_Lab4.Patterns
{
    public class Context
    {
        public Dictionary<char, int> Dictionary;

        public Context(Dictionary<char, int> dictionary)
        {
            Dictionary = dictionary;
        }
    }

    public interface IExpression
    {
        public int Interpret(Context context);
    }

    public class Number : IExpression
    {
        public char Char { get; set; }

        public Number(char number)
        {
            Char = number;
        }
        
        public int Interpret(Context context)
        {
            return context.Dictionary[Char];
        }
    }

    public class Inversion : IExpression
    {
        public IExpression Expression { get; set; }
        public Inversion(IExpression expression)
        {
            Expression = expression;
        }

        public int Interpret(Context context)
        {
            return -Expression.Interpret(context);
        }
    }

    public class Add : IExpression
    {
        private IExpression _Left { get; set; }
        private IExpression _Right { get; set; }

        public Add(IExpression left, IExpression right)
        {
            _Left = left;
            _Right = right;
        }

        public int Interpret(Context context)
        {
            return _Left.Interpret(context) + _Right.Interpret(context);
        }
    }
}
