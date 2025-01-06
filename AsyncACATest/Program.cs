<<<<<<< HEAD
﻿namespace AsyncACATest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           await Run();
        }

        static async Task Run()
        {
            Console.WriteLine("Start");
            throw new Exception("Sxal");
        }
    }
=======
﻿namespace AsyncACATest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           await Run();
        }

        static async Task Run()
        {
            Console.WriteLine("Start");
            throw new Exception("Sxal");
        }
    }
>>>>>>> 0251ad656f4137eca49cee091a3d40fb59d088d6
}