using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace AsyncFileWriterReader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Write any text in file: ");
            string inputText = Console.ReadLine();
            await Write("AsyncText.txt", inputText);
            string text = await Read("AsyncText.txt");
            Console.WriteLine(text);
        }
        static async Task Write(string filePath, string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            await using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, useAsync: true);
            await stream.WriteAsync(textBytes);

        }

        static async Task<string> Read(string filePath)
        {
            await using FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, useAsync: true);
            byte[] textBytes = new byte[stream.Length];
            await stream.ReadAsync(textBytes, 0, (int)stream.Length);
            string result = Encoding.UTF8.GetString(textBytes);
            return result;
        }
    }
}