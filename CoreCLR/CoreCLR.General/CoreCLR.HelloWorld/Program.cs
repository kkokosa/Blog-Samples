using System;
using System.Threading;

namespace CoreCLR.HelloWorld
{
    class HelloWorldClass
    {
        public void UseMe(int argument)
        {
            Console.WriteLine("Hello World, number " + argument.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeStruct number;
            number.SomeValue = 10;
            var obj = new HelloWorldClass();
            obj.UseMe(number.SomeValue);
            Console.ReadLine();
        }
    }

    struct SomeStruct
    {
        public int SomeValue;
    }
}
