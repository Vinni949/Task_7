using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{


    class Menu
    {
        static TaskManegment task = new TaskManegment();

        public void Show()
        {
            bool choice = true;
            while (choice)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер: \n1-Печатать все записи, \n2-Добавить новую запись, \n3-Удалить запись, " +
                    "\n4-Выгрузка по дате, \n5-Упорядочить записи,\n0 - exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        task.Print();
                        break;
                    case ConsoleKey.D2:
                        AddNewTask();
                        break;
                    case ConsoleKey.D3:
                        DeletedMenu();
                        break;
                    case ConsoleKey.D4:
                        DataInterval();
                        break;
                    case ConsoleKey.D5:
                        task.SortMenu();
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
        /// Создание новой записи.
        /// </summary>
        public void AddNewTask()
        {
            Console.WriteLine("ВВеди имя:");
            string name = Console.ReadLine();
            Console.WriteLine("ВВеди Фамилию:");
            string firstName = Console.ReadLine();
            Console.WriteLine("ВВеди Задачу:");
            string newTask = Console.ReadLine();
            string date = DateTime.Now.ToString();
            task.AddTaskManegment(name, firstName, newTask, date);
        }
        /// <summary>
        /// меня по удалениям записей
        /// </summary>
        static void DeletedMenu()
        {
            bool choice = true;
            while (choice)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер: \n1-Удаление по номеру, \n2-Удаление по имени, \n3-Удаление по фамилии, \n4-Удаление по дате, \n0 - exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DeletedNumber();
                        break;
                    case ConsoleKey.D2:
                        DeletedName();
                        break;
                    case ConsoleKey.D3:
                        DeletedFirstName();
                        break;
                    case ConsoleKey.D4:
                        task.DeletedByDateTime();
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
        /// удаление по номеру
        /// </summary>
        static void DeletedNumber()
        {
            Console.WriteLine("Введите номер который хотите удалить:");
            int number = int.Parse(Console.ReadLine());
            if (task.DeletedByNumber(number) > 0)
            {
                Console.WriteLine("Запись удалена!");
            }
            else
            {
                Console.WriteLine("Значение не найдено, либо введено не верное число!");
            }
        }
        /// <summary>
        /// удаление по имени
        /// </summary>
        static void DeletedName()
        {
            Console.WriteLine("Введите имя которое хотите удалить:");
            string name = Console.ReadLine();
            if (task.DeletedByName(name) > 0)
            {
                Console.WriteLine("Запись удалена!");
            }
            else
            {
                Console.WriteLine("Значение не найдено, либо введено не верное число!");
            }
        }
        /// <summary>
        /// Выгрузка по интервалу
        /// </summary>
        static void DataInterval()
        {
            Console.WriteLine("Введиет дату начала выгрузки:");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введиет дату окончания выгрузки:");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            DateInterval datainterval = new DateInterval(startDate, endDate);
            task.Load(datainterval);
            task.Print();
        }
        /// <summary>
        /// Удаление по фамилии
        /// </summary>
        static void DeletedFirstName()
        {
            Console.WriteLine("Введите Фамилию которую хотите удалить:");
            string firstName = Console.ReadLine();
            if (task.DeletedByName(firstName) > 0)
            {
                Console.WriteLine("Запись удалена!");
            }
            else
            {
                Console.WriteLine("Значение не найдено, либо введено не верное число!");
            }
        }
    }
    
}
