﻿using System.Collections.Concurrent;
using AdventOfCode.IntCodeComputer;

namespace AdventOfCode._5
{
    public class FivePointFive : Five
    {
        public FivePointFive() : base(5)
        {
        }

        public FivePointFive(int input) : base(input)
        {
        }

        protected override IIntCodeProgram CreateIntCodeProgram(BlockingCollection<IntCodeValue> input)
        {
            return IntCodeProgram.New(input);
        }
    }
}