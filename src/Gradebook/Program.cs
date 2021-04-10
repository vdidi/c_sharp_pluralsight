using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {   

            var book = new Book();
            book.AddGrade(89.1);

            List<double> grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);

            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach(var number in grades) {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Min(number, highGrade);
                result += number;
            }
            result /= grades.Count;
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The lowest grade is {highGrade}");
            Console.WriteLine($"The average grade is {result:N1}");
        }
    }
}
