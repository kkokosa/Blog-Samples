using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Numerics;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            TailRecurssionExamples examples = new TailRecurssionExamples();

            var result = examples.CalculateByApproach0();
            Console.WriteLine(result);

            result = examples.CalculateByApproach1();
            Console.WriteLine(result);

            var summary = BenchmarkRunner.Run<TailRecurssionExamples>();
        }
    }

    [MemoryDiagnoser]
    public class TailRecurssionExamples
    {
        private const int N = 20;

        [Benchmark]
        public ulong CalculateByApproach0()
        {
            return TailRecursion.Execute(() => Factorial(N, 1));
        }

        [Benchmark]
        public ulong CalculateByApproach1()
        {
            RecursionResult_Approach1<ulong> state = new RecursionResult_Approach1<ulong>();
            return TailRecursion_Approach1.Execute(() => FactorialApproach1(N, 1, state));
        }

        RecursionResult<ulong> Factorial(int n, ulong product)
        {
            if (n < 2)
                return TailRecursion.Return(product);
            return TailRecursion.Next(() => Factorial(n - 1, (ulong)n * product));
        }

        RecursionResult_Approach1<ulong> FactorialApproach1(int n, ulong product, RecursionResult_Approach1<ulong> state)
        {
            if (n < 2)
                return TailRecursion_Approach1.Return(product, state);
            return TailRecursion_Approach1.Next(() => FactorialApproach1(n - 1, (ulong)n * product, state), state);
        }
    }
}