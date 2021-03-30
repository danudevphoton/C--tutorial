using System;

namespace HelloWorld
{
    public class Car : Brand
    {
        public string Name{get;set;}

        public Car(){
            
        }

        public void GetCarName() {
            Honk();
            Console.WriteLine("Car Name : {0}",Name);
            carSound();
        }

        public override void carSound() 
        {
            Console.WriteLine("The dog says: bow wow");
        }
        
    }
}