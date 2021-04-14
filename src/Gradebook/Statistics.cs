using System;

namespace Gradebook
{
    public class Statistics {
      public double Avarage
      {
        get
        {
          return Sum / Avarage;
        }
      }
      public double High;
      public double Low;
      public char Letter;
      public double Sum;
      public int Count;

      public void Add (double number)
      {
        Sum += number;
        Count =+ 1;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
      }

      public Statistics()
      {
        Count = 0;
        High = double.MinValue;
        Low = double.MaxValue;
      }
  }
}