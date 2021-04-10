using System;
using System.Collections.Generic;

namespace Gradebook {
  class Book {

    public Book() {
      grades = new List<double>();
    }

    public void AddGrade(double grade) {

    }

    public void ShowStatistics() {
      var result = 0.0;
      var highGrade = double.MinValue;
      var lowGrade = double.MaxValue;

      foreach(var number in grades) {
          lowGrade = Math.Min(number, lowGrade);
          highGrade = Math.Max(number, highGrade);
          result += number;
      }
      result /= grades.Count;
      Console.WriteLine($"The lowest grade is {lowGrade}");
      Console.WriteLine($"The lowest grade is {highGrade}");
      Console.WriteLine($"The average grade is {result:N1}");
    }

    List<double> grades;

  }
}