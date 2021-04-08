using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {   
            var numbers = new double[3];
            numbers[0] = 12.7;

            if(args.Length > 0) {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else {
                Console.WriteLine("Hello!");
            }
        }
    }
}
