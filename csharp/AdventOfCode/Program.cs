﻿using System;
using System.Linq;
using System.Reflection;

using AdventOfCode._9;

namespace AdventOfCode
{
    public class Program
    {
        public const string DefaultTypeToRun = nameof(NinePointFive);

        public static readonly string[] DefaultArgs = new[]
        {
            DefaultTypeToRun,
            "9\\input.txt"
        };

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"No arguments, running \"{DefaultTypeToRun}\"");
                Console.WriteLine();

                var availableTypes = Assembly.GetExecutingAssembly()
                    .DefinedTypes
                    .Where(t => typeof(IRunnable).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                    .Select(t => " - " + t.Name);

                Console.WriteLine("Available types: " + Environment.NewLine + string.Join(Environment.NewLine, availableTypes));
                Console.WriteLine();

                args = DefaultArgs;
            }

            var type = Assembly.GetExecutingAssembly().DefinedTypes.Single(t => t.Name == args[0]);
            var instance = (IRunnable)Activator.CreateInstance(type);

            Console.WriteLine("Output: " + instance.Run(args));
            Console.WriteLine();

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}