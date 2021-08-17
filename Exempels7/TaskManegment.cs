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
        /// <summary>
        /// Класс записи в список
        /// </summary>
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
        /// <summary>
        /// Создание записи по входным данным
        /// </summary>
        /// <param name="name"></param>
        /// <param name="firstName"></param>
        /// <param name="task"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public TaskBook AddTaskManegment(string name, string firstName, string task, string date)
        {
            TaskBook book = new TaskBook(number, name, firstName, task, date);
            list.Add(book);
            number++;
            return book;
        }
        /// <summary>
        /// Выгрузка из файла
        /// </summary>
        /// <param name="dateInterval"></param>
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
        /// <summary>
        /// Печать всех записей
        /// </summary>
        public void Print()
        {
            foreach (TaskBook task in list)
            {
                task.Print(new ConsolePrinter());
                Console.WriteLine();
            }
        }
        /// <summary>
        /// сохранение в файл
        /// </summary>
        public string Save()
        {
            string messege;
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
                return messege="Запись выполнена";
            }
            catch (Exception e)
            {
                return messege = e.Message;
            }
        }
        /// <summary>
        /// удаление по номеру
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int DeletedByNumber(int number)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Number == number)
                {
                    list.RemoveAt(i);
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// удаление по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int DeletedByName(string name)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    list.RemoveAt(i);
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// удаление по фамилии
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public int DeletedByFirstName(string firstName)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].FirstName == firstName)
                {
                    list.RemoveAt(i);
                    count++;
                }
            }
            return count;
        }
    /// <summary>
    /// удаление по дате
    /// </summary>
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
        /// <summary>
        /// Меню сортировки
        /// </summary>
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
        /// <summary>
        /// сортировка по номеру
        /// </summary>
        public void SortByNumber()
        {
            list.Sort((a, b) => a.Number.CompareTo(b.Number));
            Print();
        }
        /// <summary>
        /// Сортировка по имени
        /// </summary>
        public void SortByName()
        {
            list.Sort((a, b) => a.Name.CompareTo(b.Name));
            Print();
        }
        /// <summary>
        /// сортировка по фамилии
        /// </summary>
        public void SortByFirstName()
        {
            list.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
            Print();
        }
        /// <summary>
        /// сортировка по дате
        /// </summary>
        public void SortByDate()
        {
            list.Sort((a, b) => a.Date.CompareTo(b.Date));
            Print();
        }
    }
}