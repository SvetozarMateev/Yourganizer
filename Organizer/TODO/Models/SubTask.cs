using System;
using TODO.Contracts;

namespace TODO.Models
{
    public class SubTask : Task, ITask, ISubTask,ISaveable
    {
        private DateTime dueDate;
        private double importancePercent;

        public SubTask(string title, Priority priority, string description, DateTime dueDate, double importancePercent, DateTime start = default(DateTime))
            : base(title, priority, description,start)
        {
           
            this.DueDate = dueDate;
            this.ImportancePercent = importancePercent;
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
