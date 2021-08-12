using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace work7
{
    class TaskManegment
    {
        List<TaskBook> list = new List<TaskBook>();
        int number = 1;
        const string writePath = @"Class.txt";
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
        public TaskBook AddTaskManegment()
        {
            Console.WriteLine("ВВеди имя:");
            string name = Console.ReadLine();
            Console.WriteLine("ВВеди Фамилию:");
            string firstName = Console.ReadLine();
            Console.WriteLine("ВВеди Задачу:");
            string task = Console.ReadLine();
            string date = DateTime.Now.ToString();
            TaskBook book = new TaskBook(number, name, firstName, task, date);
            list.Add(book);
            number++;
            Save();
            return book;
        }
        private void Load()
        {
            try
            {
                using (StreamReader stream = new StreamReader(writePath))
                {
                    while (!stream.EndOfStream)
                    {
                        string entry = stream.ReadLine();
                        string[] data = entry.Split("|");
                        int number = int.Parse(data[0]);
                        string name = data[1];
                        string firstName = data[2];
                        string task = data[3];
                        string date = data[4];
                        TaskBook book = new TaskBook(number, name, firstName, task, date);
                        list.Add(book);
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
                task.Print();
            }
            Console.WriteLine();
        }

        private void Save()
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
        public void DeletedMenu()
        {
            bool choice = true;
            while (choice)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер: \n1-Удаление по номеру, \n2-Удаление по имени, \n3-Удаление по фамилии, \n4-Удаление по дате, \n0 - exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DeletedByNumber();
                        break;
                    case ConsoleKey.D2:
                        DeletedByName();
                        break;
                    case ConsoleKey.D3:
                        DeletedByFirstName();
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

        private void DeletedByNumber()
        {
            Console.WriteLine("Введите номер который хотите удалить:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == number)
                {
                    list.RemoveAt(i);
                }
                else { Console.WriteLine("Значение не найдено, либо введено не верное число!"); }
            }
            Save();
        }
        private void DeletedByName()
        {
            Console.WriteLine("Введите имя которое хотите удалить:");
            string name = Console.ReadLine();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    list.RemoveAt(i);
                }
                else { Console.WriteLine("Значение не найдено, либо введено не верное число!"); }
            }
            Save();
        }
        private void DeletedByFirstName()
        {
            Console.WriteLine("Введите Фамилию которую хотите удалить:");
            string firstName = Console.ReadLine();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirstName == firstName)
                {
                    list.RemoveAt(i);
                }
                else { Console.WriteLine("Значение не найдено, либо введено не верное число!"); }
            }
            Save();
        }
        private void DeletedByDateTime()
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
        public void AddTask()
        {
            Console.WriteLine("Введите номер в котором хотите отредактировать запись:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == number)
                {
                    list[i].AddTask(Console.ReadLine());
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