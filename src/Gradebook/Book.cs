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
      var result = new Statistics();
      using(var reader = File.OpenText($"{Name}.txt"))
      {
        var line = reader.ReadLine();
        while(line != null)
        {
          var number = double.Parse(line);
          result.Add(number);
          line = reader.ReadLine();
        }
      }

      return result;
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

      for(var index = 0; index < grades.Count; index += 1) {
          result.Add(grades[index]);
      }

      return result;
    }

    private List<double> grades;
  }
}