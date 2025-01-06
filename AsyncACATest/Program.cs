namespace AsyncACATest
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
}