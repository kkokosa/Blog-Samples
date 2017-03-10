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
        }
    }

    class TailRecurssionExamples
    {
        public BigInteger CalculateByApproach0(int n)
        {
            return TailRecursion.Execute(() => Factorial(n, 1));
        }

        RecursionResult<BigInteger> Factorial(int n, BigInteger product)
        {
            if (n < 2)
                return TailRecursion.Return(product);
            return TailRecursion.Next(() => Factorial(n - 1, n * product));
        }


    }
}