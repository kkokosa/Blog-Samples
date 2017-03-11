using System;

namespace CSharp7
{
    /// <summary>
    /// Taken from https://www.thomaslevesque.com/2011/09/02/tail-recursion-in-c/
    /// </summary>
    public static class TailRecursion_Approach1
    {
        public static T Execute<T>(Func<RecursionResult_Approach1<T>> func)
        {
            do
            {
                var bounce = func();
                if (bounce.NextStep == null)
                    return bounce.Result;
                func = bounce.NextStep;
            } while (true);
        }

        public static RecursionResult_Approach1<T> Return<T>(T result, RecursionResult_Approach1<T> state)
        {
            state.Result = result;
            state.NextStep = null;
            return state;
        }

        public static RecursionResult_Approach1<T> Next<T>(Func<RecursionResult_Approach1<T>> nextStep, RecursionResult_Approach1<T> state)
        {
            state.Result = default(T);
            state.NextStep = nextStep;
            return state;
        }
    }

    public class RecursionResult_Approach1<T>
    {
        public T Result;
        public Func<RecursionResult_Approach1<T>> NextStep;
    }

}