using System;
using System.Numerics;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            TailRecurssionExamples examples = new TailRecurssionExamples();

            var result = examples.CalculateByApproach0(6);
            Console.WriteLine(result);

            result = examples.CalculateByApproach1(6);
            Console.WriteLine(result);
        }
    }

    class TailRecurssionExamples
    {
        public BigInteger CalculateByApproach0(int n)
        {
            return TailRecursion.Execute(() => Factorial(n, 1));
        }

        public BigInteger CalculateByApproach1(int n)
        {
            RecursionResult_Approach1<BigInteger> state = new RecursionResult_Approach1<BigInteger>();
            return TailRecursion_Approach1.Execute(() => FactorialApproach1(n, 1, state));
        }

        RecursionResult<BigInteger> Factorial(int n, BigInteger product)
        {
            if (n < 2)
                return TailRecursion.Return(product);
            return TailRecursion.Next(() => Factorial(n - 1, n * product));
        }

        RecursionResult_Approach1<BigInteger> FactorialApproach1(int n, BigInteger product, RecursionResult_Approach1<BigInteger> state)
        {
            if (n < 2)
                return TailRecursion_Approach1.Return(product, state);
            return TailRecursion_Approach1.Next(() => FactorialApproach1(n - 1, n * product, state), state);
        }
    }
}