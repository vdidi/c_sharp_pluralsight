using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {   

            IBook book = new DiskBook("My Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Avarage}");
        }
    }
}
