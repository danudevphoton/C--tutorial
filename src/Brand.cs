using System;

namespace HelloWorld
{
    public class Brand
    {

        public Brand(){

        }

        public void Honk() {
            Console.WriteLine("tut , tut!");
        }

        public virtual void carSound() 
        {
            Console.WriteLine("The animal makes a sound");
        }
        
    }
}