using System;
using System.IO;
using System.Threading.Tasks;

namespace work7

{
    class Program
    {
        static async Task Main(string[] args)
        {
            string writePath = @"C:\Users\pumba\source\repos\Exempels7\Class.txt";

            int number = 1;
            string Name = Console.ReadLine(); 
            string FirstName = Console.ReadLine();
            string Task = Console.ReadLine();
            string data = DateTime.Now.ToString();
            TaskBook book = new TaskBook(number,Name,FirstName,Task,data);
            Console.WriteLine(DateTime.Now);
            book.Print();
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync("");
                    await sw.WriteAsync(book.GetNumber.ToString());
                    await sw.WriteAsync("| " + book.GetName);
                    await sw.WriteAsync("| " + book.GetFirstName);
                    await sw.WriteAsync("| " + book.GetTask);
                    await sw.WriteAsync("| " + book.GetDate);
                    await sw.WriteAsync("|");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
