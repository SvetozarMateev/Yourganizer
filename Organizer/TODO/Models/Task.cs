using System;
using TODO.Contracts;
using TODO.Models;
using TODO.Utils.Validator;

namespace TODO
{
    public class Task : ITask, ISaveable
    {
        private string title;
        private string description;
        private Priority priority;
        private IReminder reminder;
        private DateTime start;

        public Task(string title, Priority priority, string description, DateTime start = default(DateTime), Reminder reminder = null)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Start = start;
            this.Reminder = reminder;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                Validator.CannotBeNullOrEmpty(value);

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                Validator.CannotBeNullOrEmpty(value);

                this.description = value;
            }
        }

        public Priority Priority
        {
            get
            {
                return this.priority;
            }
            private set
            {
                this.priority = value;
            }
        }

        public IReminder Reminder
        {
            get
            {
                return this.reminder;
            }
            set
            {
                this.reminder = value;
            }
        }

        public DateTime Start
        {
            get
            {
                return this.start;
            }
            private set
            {
                if (value == default(DateTime))
                {
                    this.start = DateTime.Now;
                }
                else
                {
                    this.start = value;

                }
            }
        }
        public virtual string AdditionalInformation()
        {
            return "";
        }
        public virtual string FormatUserInfoForDB()
        {
            return $"{this.Title}:::{this.Priority}:::{(this.Reminder==null ? "None" : this.Reminder.ToString())}" +
                $":::{this.Start.ToString("dd/MM/yyyy")}:::{AdditionalInformation()}:::{this.Description}";
        }
        public override string ToString()
        {
            return $"   ---> {this.Title} <--- created: {this.Start}" +
                   Environment.NewLine +
                   $"       <<{this.Description}>>" + Environment.NewLine +
                   $"       You will be reminder at: {this.Reminder}";

        }
    }
}
