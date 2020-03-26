using System;
using System.Collections.Generic;
using System.IO;

namespace KizhiPart1
{
    public class Interpreter
    {
        private const string VariableNotFoundError = "Переменная отсутствует в памяти";
        private static Dictionary<string, Action<string[]>> kizhiCommands;
        private readonly Dictionary<string, int> variables;
        private readonly TextWriter writer;

        public Interpreter(TextWriter writer)
        {
            this.writer = writer;
            variables = new Dictionary<string, int>();
            kizhiCommands = new Dictionary<string, Action<string[]>>
            {
                {"set", SetVariable},
                {"sub", Sub},
                {"print", Print},
                {"rem", Remove}
            };
        }

        public void ExecuteLine(string command)
        {
            if (command is null)
                return;

            var parsedCommand = command.Split();
            if (!kizhiCommands.ContainsKey(parsedCommand[0]))
            {
                throw new ArgumentException("Wrong command", command);
            }

            kizhiCommands[parsedCommand[0]].Invoke(parsedCommand);
        }

        private void SetVariable(string[] args)
        {
            var name = args[1];
            if (int.TryParse(args[2], out var value))
            {
                if (value > 0)
                {
                    variables[name] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(value.ToString(), "Value should be greater than 0");
                }
            }
        }

        private void Sub(string[] args)
        {
            var name = args[1];
            if (int.TryParse(args[2], out var value))
            {
                if (variables.ContainsKey(name))
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(value.ToString(), "Value should be greater than 0");
                    }

                    if (variables[name] < value)
                    {
                        throw new ArithmeticException("Operation result should be greater than 0");
                    }

                    variables[name] -= value;
                }
                else
                {
                    writer.WriteLine(VariableNotFoundError);
                }
            }
        }

        private void Print(string[] args)
        {
            var name = args[1];
            if (variables.ContainsKey(name))
            {
                writer.WriteLine(variables[name]);
            }
            else
            {
                writer.WriteLine(VariableNotFoundError);
            }
        }

        private void Remove(string[] args)
        {
            var name = args[1];
            if (variables.ContainsKey(name))
            {
                variables.Remove(name);
            }
            else
            {
                writer.WriteLine(VariableNotFoundError);
            }
        }
    }
}