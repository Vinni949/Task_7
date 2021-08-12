using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace work7

{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManegment task = new TaskManegment();
            bool choice = true;
            while (choice)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер: \n1-Печатать все записи, \n2-Добавить новую запись, \n3-Редактировать запись, \n4-Удалить запись, \n5-Упорядочить записи,\n0 - exit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        task.Print();
                        break;
                    case ConsoleKey.D2:
                        task.AddTaskManegment();
                        break;
                    case ConsoleKey.D3:
                        task.AddTask();
                        break;
                    case ConsoleKey.D4:
                        task.DeletedMenu();
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
        
    }
}
