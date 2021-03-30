using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    public delegate void GradeAddDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name){
            Name = name;
        }

        public string Name{
            get;set;
        }
        
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name){

        }

        public override event GradeAddDelegate GradeAdded;

        public override Statistics GetStatistics(){
            var resultx = new Statistics();
            var count = 0;
            using (var reader = File.OpenText($"{Name}.txt")){
                var line = reader.ReadLine();
                while (line != null){
                    var number = double.Parse(line);
                    resultx.Add(number);
                    line = reader.ReadLine();
                    count++;
                }
            }

            File.AppendAllText($"{Name}.txt", "Avg : " +resultx.average+ Environment.NewLine);
            File.AppendAllText($"{Name}.txt", "Letter : " +resultx.letter+ Environment.NewLine);
            return resultx;
        }

        public override void AddGrade(double grade){
            using(var writer = File.AppendText($"{Name}.txt")){
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }   
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook {

        public Book(string name) : base(name){

        }

        public abstract event GradeAddDelegate GradeAdded;

        public abstract Statistics GetStatistics();

        public abstract void AddGrade(double grade);

    }

    public class InMemoryBook : Book {

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        private List<double> grades;
        private string name;
        public string Name{ get; set; }
        public const string CATEGORY = "Science";

        public override void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public void ShowStats(){
            Console.WriteLine("-----");
            var getresult = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (var item in grades)
            {
                lowGrade = Math.Min(item, lowGrade);
                highGrade = Math.Max(item, highGrade);
                
                getresult += item;
            }

            getresult /= grades.Count;
            Console.WriteLine($"{Name}");
            Console.WriteLine($"The high is : {highGrade:N1}");
            Console.WriteLine($"The low is : {lowGrade:N1}");
            Console.WriteLine($"The average is : {getresult:N1}");
        }

        public override event GradeAddDelegate GradeAdded;

        public override Statistics GetStatistics(){
            var resultx = new Statistics();
            // resultx.average = 0.0;
            // resultx.high = double.MinValue;
            // resultx.low = double.MaxValue;

            for (var index = 0; index < grades.Count; index+= 1) {
                resultx.Add(grades[index]);
                // resultx.low = Math.Min(grades[index], resultx.low);
                // resultx.high = Math.Max(grades[index], resultx.high);
                
                //resultx.average += grades[index];
            }

            //resultx.average /= grades.Count;
            //done:

            // switch (resultx.average)
            // {
            //     case var d when d >= 90.0:
            //         resultx.letter = 'A';
            //         break;
            //     case var d when d >= 80.0:
            //         resultx.letter = 'B';
            //         break;
            //     case var d when d >= 65.0:
            //         resultx.letter = 'C';
            //         break;
            //     case var d when d >= 40.0:
            //         resultx.letter = 'D';
            //         break;
            //     default:
            //         resultx.letter = 'E';
            //         break;
            // }
            

            return resultx;
        }

    }    
}