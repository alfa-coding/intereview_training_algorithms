using System;
using System.Collections.Generic;

namespace Algorithms.Library
{
    class PolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> numbers = new();
            var operators = new Dictionary<string, Func<int, int, int>>(){
            {"+", (a,b)=>a+b},
            {"-", (a,b)=>a-b},
            {"*", (a,b)=>a*b},
            {"/", (a,b)=>a/b}
        };


            for (int i = 0; i < tokens.Length; i++)
            {
                var tmpToken = tokens[i];
                if (operators.ContainsKey(tmpToken))
                {
                    var op1 = numbers.Pop();
                    var op2 = numbers.Pop();
                    var rOp = operators[tmpToken](op2, op1);
                    numbers.Push(rOp);

                }
                else
                {
                    numbers.Push(int.Parse(tmpToken));
                }
            }

            return numbers.Pop();

        }
    }
}