using System;
using System.Collections.Generic;
using System.Linq;

class Parenthesis
{
    public static void Run()
    {
        //var array = Tools.MakeArray(1, 2, 3);
        Console.WriteLine(new Solution().IsValid("(){}[]({[]})"));
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(c);
                        break;

                    case ')':
                        {
                            if (stack.Count == 0)
                                return false;
                            var o = stack.Pop();
                            if (o != '(')
                                return false;
                            break;
                        }
                    case '[':
                        stack.Push(c);
                        break;

                    case ']':
                        {
                            if (stack.Count == 0)
                                return false;
                            var o = stack.Pop();
                            if (o != '[')
                                return false;
                            break;
                        }
                    case '{':
                        stack.Push(c);
                        break;

                    case '}':
                        {
                            if (stack.Count == 0)
                                return false;
                            var o = stack.Pop();
                            if (o != '{')
                                return false;
                            break;
                        }
                }
            }
            return stack.Count == 0;

        }
    }
}