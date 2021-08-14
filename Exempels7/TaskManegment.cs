using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Work7
{
    class TaskManegment
    {
        static List<TaskBook> list = new List<TaskBook>();
        const string writePath = @"Class.txt";
        int number = 1;
        public TaskManegment()
        {
            if (File.Exists(writePath))
            {
                Load();
                Print();
            }
            else
            {
                File.Create(@"Class.txt");
            }
        }
        public TaskBook AddTaskManegment(string name, string firstName, string task, string date)
        {
            TaskBook book = new TaskBook(number, name, firstName, task, date);
            list.Add(book);
            Save();
            number++;
            return book;
        }
        public void Load(DateInterval dateInterval=null)
        {
            try
            {
                using (StreamReader stream = new StreamReader(writePath))
                {
                    while (!stream.EndOfStream)
                    {

                        string entry = stream.ReadLine();
                        string[] data = entry.Split("|");
                        string name = data[1];
                        string firstName = data[2];
                        string task = data[3];
                        string date = data[4];
                        TaskBook book = new TaskBook(number,name, firstName, task, date);
                        if (dateInterval == null||dateInterval.StartDate<=book.Date&&dateInterval.EndDate>= book.Date)
                        { 
                            list.Add(book);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Print()
        {
            foreach (TaskBook task in list)
            {
                task.Print(new ConsolePrinter());
                Console.WriteLine();
            }
        }

        static void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath))
                {
                    foreach (TaskBook task in list)
                    {
                        string entry = String.Join("|", task.Number, task.Name, task.FirstName, task.Task, task.Date.ToShortDateString());
                        sw.WriteLine(entry);
                    }
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }


        public int DeletedByNumber(int number)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == number)
                {
                    list.RemoveAt(i);
                    Save();
                    count++;  
                }
               
            }
            if (count > 0)
            { 
                Save(); 
            }
            return count;
        }
        public int DeletedByName(string name)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    list.RemoveAt(i);
                    Save();
                    count++;
                }
            }
            if (count > 0)
            {
                Save();
            }
            return count;
        }
        public int DeletedByFirstName(string firstName)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirstName == firstName)
                {
                    list.RemoveAt(i);
                    Save();
                    count++;
                }
            }
            if (count > 0)
            {
                Save();
            }
            return count;
        }
    
        public void DeletedByDateTime()
        {
            Console.WriteLine("Введите дату которую хотите удалить:");
            DateTime date =DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Date == date)
                {
                    list.RemoveAt(i);
                }
                else { Console.WriteLine("Значение не найдено, либо введено не верное число!"); }
            }
            Save();
        }
        
        public void SortMenu()
        {
            bool choice = true;
            while (choice)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер: \n1-Сортировать по номеру, \n2-Сортировать по имени, \n3-Сортировать по фамилии, \n4-Сортировать по дате, \n0 - exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        SortByNumber();
                        break;
                    case ConsoleKey.D2:
                        SortByName();
                        break;
                    case ConsoleKey.D3:
                        SortByFirstName();
                        break;
                    case ConsoleKey.D4:
                        DeletedByDateTime();
                        break;
                    case ConsoleKey.D0:
                        choice = false;
                        break;
                    default:
                        Console.WriteLine("Нажата неверна клавиша, введите снова!");
                        break;
                }
            }
        }

        public void SortByNumber()
        {
            list.Sort((a, b) => a.Number.CompareTo(b.Number));
            Print();
        }
        public void SortByName()
        {
            list.Sort((a, b) => a.Name.CompareTo(b.Name));
            Print();
        }
        public void SortByFirstName()
        {
            list.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            Print();
        }
        public void SortByDate()
        {
            list.Sort((a, b) => a.Date.CompareTo(b.Date));
            Print();
        }
    }
}