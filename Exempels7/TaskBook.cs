using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    class TaskBook
    {/// <summary>
    /// клас создания обьектов для записи
    /// </summary>
    /// <param name="number"></param>
    /// <param name="name"></param>
    /// <param name="firstName"></param>
    /// <param name="task"></param>
    /// <param name="data"></param>
        public TaskBook(int number, string name, string firstName, string task, string data)
        {
            this.Number = number;
            this.Name = name;
            this.FirstName = firstName;
            this.Task = task;
            this.Date = DateTime.Parse(data);
        }

        public string Task
        { get; set; }
        
        public string Print()
        {
            return $"\n{this.Number}\n{this.Name}\n{this.FirstName}\n{this.Task}\n{this.Date}\n";
        }
        public string Name
        { get; set; }
        public int Number
        { get; set; }

        public string FirstName
        { get; set; }

        public DateTime Date
        {get; set;}
    }
}
