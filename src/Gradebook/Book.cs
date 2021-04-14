using System;
using System.Collections.Generic;
using System.IO;

namespace Gradebook {

  public class NamedObject {

    public NamedObject(string name) {
      Name = name;
    } 
    public string Name
    {
      get;
      set;
    }
  }

  public interface IBook {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    //event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    protected Book(string name) : base(name) {}

    public abstract void AddGrade(double grade);

    public abstract Statistics GetStatistics();
  }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override void AddGrade(double grade)
    {
      using(var writer = File.AppendText($"{Name}.txt"))
      {
        writer.WriteLine(grade);
      }
    }

    public override Statistics GetStatistics()
    {
      throw new NotImplementedException();
    }
  }

  public class InMemoryBook : Book {

    public InMemoryBook(string name): base(name) {
      grades = new List<double>();
      Name = name;
    }

    public override void AddGrade(double grade) {
      grades.Add(grade);
    }

    public override Statistics GetStatistics() {
      var result = new Statistics();
      result.Avarage = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach(var grade in grades) {
          result.Low = Math.Min(grade, result.Low);
          result.High = Math.Max(grade, result.High);
          result.Avarage += grade;
      }
      result.Avarage /= grades.Count;

      return result;
    }

    private List<double> grades;
  }
}