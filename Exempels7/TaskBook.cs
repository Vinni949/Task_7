using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    class TaskBook
    {
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
        
        public void Print(IPrinter printer)
        {
            printer.Print(Number + "\n" + Name+"\n"+FirstName + "\n" + Task + "\n" + Date);
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
