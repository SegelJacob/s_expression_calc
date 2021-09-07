using System;
using System.Collections.Generic;
using System.Text;

namespace s_expression_Calc
{
    class Program
    {
        // Driver method for testing
        public static void Main(string[] args)
        {
            int result;
            Console.WriteLine("Enter string");
            string exp = Console.ReadLine();
            result = evalExpression(exp);
            Console.WriteLine(result);
        }

        // Evaluates the expression provided by user input
        public static int evalExpression(string exp)
        {
            char[] tokens = exp.ToCharArray();

            Stack<int> numValues = new Stack<int>();

            Stack<char> operators = new Stack<char>();

            Stack<string> opStrings = new Stack<string>(); 

            for (int i = 0; i < tokens.Length; i++)
            {
                // Skips spaces
                if (tokens[i] == ' ')
                {
                    continue;
                }

                // Checks if character is a digit
                if (Char.IsDigit(tokens[i]))
                {
                    StringBuilder numBuffer = new StringBuilder();

                    // While characters are digits, collect full number in a buffer, parse to integer and add to stack
                    while (i < tokens.Length && Char.IsDigit(tokens[i]))
                    {
                        numBuffer.Append(tokens[i++]);
                    }

                    numValues.Push(int.Parse(numBuffer.ToString()));

                    i--;
                }
                // If the character is an opening paranthesis, add to stack of operators
                else if (tokens[i] == '(')
                {
                    operators.Push(tokens[i]);
                }

                // If the character is a closing parenthesis, solve values in the brace
                else if (tokens[i] == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        numValues.Push(applyOp(operators.Pop(), numValues.Pop(), numValues.Pop()));
                    }
                    operators.Pop();
                }

                // If the character is 'a', add string to stack, check operator and solve values in the brace
                else if (tokens[i] == 'a')
                {
                    StringBuilder opBuffer = new StringBuilder();
                     while (tokens[i] != ' ')
                     {
                        opBuffer.Append(tokens[i++]);
                     }

                    while (operators.Count > 0 && checkOp(tokens[i], operators.Peek()))
                    {
                        numValues.Push(applyOp(operators.Pop(), numValues.Pop(), numValues.Pop()));
                    }

                    opStrings.Push(opBuffer.ToString());
                    operators.Push('+');

                    i--;                
                }

                // If the character is 'm', add string to stack, check operator and solve values in the brace
                else if (tokens[i] == 'm')
                {
                    StringBuilder opBuffer = new StringBuilder();
                    while (tokens[i] != ' ')
                    {
                        opBuffer.Append(tokens[i++]);
                    }

                    while (operators.Count > 0 && checkOp(tokens[i], operators.Peek()))
                    {
                        numValues.Push(applyOp(operators.Pop(), numValues.Pop(), numValues.Pop()));
                    }

                    opStrings.Push(opBuffer.ToString());
                    operators.Push('*');

                    i--;
                }
                // If characters are invalid, return exception message and '0' as the result
                else
                {
                    Console.WriteLine("Invalid State");
                    return 0;
                }
            }

            // Solve values after looping through characters
            while (operators.Count > 0)
            {
                numValues.Push(applyOp(operators.Pop(), numValues.Pop(), numValues.Pop()));
            }
            try
            {
                // Return top value of the numValeus stack
                return numValues.Pop();
            }
            // If value in the stack is invalid, return exception message and '0' as the result
            catch (Exception)
            {
                Console.WriteLine("Invalid State!");
                return 0;
            }
        }

        // Apply operator on values num1 and num2 (in the case of either addition or multiplication)
        // More function types can be added here
        // More arguments can be added to support more than 2
        public static int applyOp(char op, int num2, int num1)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '*':
                    return num1 * num2;
            }
            return 0;
        }

        // Return false if either character provided is an operator or a paranthesis
        public static bool checkOp(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if (op1 == '*' || op1 == '+')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
