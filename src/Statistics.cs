using System;
namespace HelloWorld
{
    public class Statistics
    {
        public double high;
        public double low;   
        public double average{
            get { return Sum/Count;}
        }
        public char letter{
            get {
                switch (average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                        
                    case var d when d >= 80.0:
                        return 'B';
                        
                    case var d when d >= 65.0:
                        return 'C';
                        
                    case var d when d >= 40.0:
                        return 'D';
                        
                    default:
                        return 'E';
                        
                }
            }
        }
        public double Sum;
        public int Count;
        
        public void Add(double number){
            Sum += number;
            Count += 1;
            low = Math.Min(number, low);
            high = Math.Max(number, high);
        }

        public Statistics(){
            Count = 0;
            //average = 0.0;
            Sum = 0.0;
            high = double.MinValue;
            low = double.MaxValue;
        }
    }
}