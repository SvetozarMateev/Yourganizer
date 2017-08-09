using System;
using TODO.Contracts;

namespace TODO.Models
{
    public class SubTask : Task, ITask, ISubTask,ISaveable
    {
        private DateTime dueDate;
        private double importancePercent;
                
        public SubTask(string title, Priority priority, string description, DateTime dueDate, double importancePercent)
            : base(title, priority, description)
        {
            this.DueDate = dueDate;
            this.ImportancePercent = importancePercent;
        }

        public SubTask(string title, Priority priority, string description, DateTime dueDate, double importancePercent, DateTime dateOfCreation = default(DateTime))
            : this(title, priority, description, dueDate, importancePercent)
        {
            this.DateOfCreation = dateOfCreation;
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }

            private set
            {
                this.dueDate = value;
            }

        }

        public double ImportancePercent
        {
            get
            {
                return this.importancePercent;
            }
            set
            {
                this.importancePercent = value;
            }
        }

        public override string AdditionalInformation()
        {
            return $"{this.DueDate}:::{this.ImportancePercent}";
        }    
    }
}
