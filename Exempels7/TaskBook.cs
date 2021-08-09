using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work7
{
    class TaskBook
    {
        private int Number;
        private string Name;
        private string FirstName;
        private string Task;
        private string Data;

        public TaskBook(int Number, string Name, string FirstName, string Task, string data)
        {
            this.Number = Number;
            this.Name = Name;
            this.FirstName = FirstName;
            this.Task = Task;
            this.Data = data;
        }

        public void EditingName(string NewName)
        {
            Name = NewName;
        }
        public void EditingNewTask(string NewTask)
        {
            Task = NewTask;
        }
        public void AddTask(string AddTask)
        {
            Task += AddTask;
        }

        public void AddTime(DateTime data)
        {
            Data += ", ";
            Data += data;
        }
        public void Print()
        {
            Console.WriteLine(Number + "\n" + Name+"\n"+FirstName + "\n" + Task + "\n" + Data);
        }
        public string GetName
        {
            get
            {
                return Name;
            }
        }
        public int GetNumber
        {
            get
            {
                return Number;
            }
        }
        public string GetFirstName
        {
            get
            {
                return FirstName;
            }
        }
        public string GetTask
        {
            get
            {
                return Task;
            }
        }
        public string GetDate
        {
            get
            {
                return Data;
            }
        }
    }
}
