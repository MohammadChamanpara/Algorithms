using System;
using System.Collections.Generic;

public class WordMachine
{
    public static void Run()
    {
        string input1 = "3 DUP 5 - -";
        string input2 = "13 DUP 4 POP 5 DUP + DUP + -";
        var result = new WordMachine().solution(input2);
        Console.WriteLine(result);
    }

    const int Error = -1;
    public int solution(string S)
    {
        var stack = new Stack<uint>();

        var inputs = S.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var input in inputs)
            if (!Process(stack, input))
                return Error;

        if (stack.Count == 0)
            return Error;

        return (int)stack.Peek();
    }

    private bool Process(Stack<uint> stack, string input)
    {
        switch (input)
        {
            case "DUP":
                {
                    if (stack.Count < 1)
                        return false;

                    stack.Push(stack.Peek());
                    break;
                }

            case "POP":
                {
                    if (stack.Count < 1)
                        return false;

                    stack.Pop();
                    break;
                }

            case "+":
                {
                    if (stack.Count < 2)
                        return false;

                    uint first = stack.Pop();
                    uint second = stack.Pop();
                    uint sum = first + second;

                    /* -- Overflow -- */
                    if (sum < first || sum < second)
                        return false;

                    stack.Push(sum);
                    break;
                }

            case "-":
                {
                    if (stack.Count < 2)
                        return false;

                    uint first = stack.Pop();
                    uint second = stack.Pop();
                    uint sub = first - second;

                    /* -- Overflow and negative results -- */
                    if (sub > first) 
                        return false;

                    stack.Push(sub);
                    break;
                }

            default:
                {
                    uint number;

                    if (!uint.TryParse(input, out number))
                        return false;

                    stack.Push(number);
                    break;
                }
        }
        return true;
    }

    /* --  Time Complexity O(n)   -- */
    /* --  Space Complexity O(n)  -- */
}