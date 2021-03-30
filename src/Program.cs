using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // #1
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine("your last name?");
            var lastname = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Hello, {name} {lastname}, on {date:d} at {date:t}!");

            // #3
            // string Name = "\"Pragim\"";
            // Console.WriteLine("{0}",Name);
            // string Name2 = "One\nTwo\nThree";
            // Console.WriteLine("{0}",Name2);

            // #4
            Car car = new Car();
            car.Name = "tescar";
            car.GetCarName(); 
            //MyMethod2();

            var book = new DiskBook($"{name} {lastname} Stats");
            book.GradeAdded += OnGradeAdded;
            
            EnterGrades(book);

            // book.AddGrade(10.0);
            // book.AddGrade(75.3);
            // book.AddGrade(70.0);
            // book.AddGrade(58.7);
            //book.ShowStats();

            var result = book.GetStatistics();
            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"The high is : {result.high:N1}");
            Console.WriteLine($"The low is : {result.low:N1}");
            Console.WriteLine($"The average is : {result.average:N1}");
            Console.WriteLine($"The letter is : {result.letter}");
            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);

        }

        private static void EnterGrades(IBook book){
            var done = false;
            Console.WriteLine("Input Harry : ");
            while (!done)
            {
                Console.WriteLine("Enter or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                     Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                     Console.WriteLine(ex.Message);
                }
                finally {
                    Console.WriteLine("**");
                }
                
            }
        }

        static void OnGradeAdded(object sender, EventArgs e) {
            Console.WriteLine("A grade was Added");
        }

        static void MyMethod2() 
        {
            List<dynamic> grades = new List<dynamic>() {12.7,10.3,6.11,4.1};
            grades.Add(56.1);

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
            Console.WriteLine($"The high is : {highGrade:N1}");
            Console.WriteLine($"The low is : {lowGrade:N1}");
            Console.WriteLine($"The average is : {getresult:N1}");
        }
    }
}
                                    