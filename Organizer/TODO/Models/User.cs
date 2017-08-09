using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;
using TODO.Utils.Validator;

namespace TODO.Models
{
    public class User : IUser, ISaveable
    {
        private string username;
        private string password;
        private ICollection<INotebook> notebooks;
        private ICollection<ITask> tasks;
        private ICollection<ILongTermTask> longTermTasks;

        public User(string username, string password, ICollection<INotebook> notebooks = null, ICollection<ITask> tasks = null,
            ICollection<ILongTermTask> longTermTasks=null)
        {
            this.Username = username;
            this.Password = password;
            this.Notebooks = notebooks;
            this.Tasks = tasks;
            this.LongTermTasks = longTermTasks;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.CannotBeNullOrEmpty(value);
                Validator.CheckNameLength(value, Constants.MinUserLength);
                Validator.CheckUserName(value);

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.CheckPasswordStrength(value);

                this.password = value;
            }
        }

        public ICollection<INotebook> Notebooks
        {
            get
            {
                return this.notebooks;
            }
            private set
            {
                if (value == null)
                {
                    this.notebooks = new List<INotebook>();
                }
                else
                {
                    this.notebooks = value;

                }
            }
        }

        public ICollection<ITask> Tasks
        {
            get
            {
                return this.tasks;
            }
            private set
            {
                if (value != null)
                {
                    this.tasks = value;
                }
                else
                {
                    this.tasks = new List<ITask>();
                }

            }
        }

        public ICollection<ILongTermTask> LongTermTasks
        {
            get
            {
                return this.longTermTasks;
            }
            private set
            {
                if (value == null)
                {
                    this.longTermTasks = new List<ILongTermTask>();
                }
                else
                {
                    this.longTermTasks = value;

                }
            }
        }


        public void AddNotebook(INotebook notebook)
        {
            this.Notebooks.Add(notebook);
        }

        public void DeleteNotebook()
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            this.Tasks.Add(task);
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string FormatUserInfoForDB()
        {
            return $"{this.Username} {this.Password}" +
                $"{(this.Notebooks.Count == 0 ? string.Empty : Environment.NewLine + string.Join(Environment.NewLine, this.Notebooks.Select(x => x.FormatUserInfoForDB())))}"
                + Environment.NewLine + "---***---"
                + $"{(this.Tasks.Count == 0 ? string.Empty : Environment.NewLine + string.Join(Environment.NewLine, this.Tasks.Select(x => x.FormatUserInfoForDB())))}"
                 + Environment.NewLine + "___***___" + 
                $"{(this.LongTermTasks.Count ==0 ?  string.Empty: Environment.NewLine + string.Join(Environment.NewLine, this.LongTermTasks.Select(x=>x.FormatUserInfoForDB())))}"
                +Environment.NewLine+"---***---"+Environment.NewLine;
        }

        public void AddLongTermTask(ILongTermTask longTermTask)
        {
            this.LongTermTasks.Add(longTermTask);
        }
        public override string ToString()
        {
            return $"__________{this.Username}__________" + Environment.NewLine +
                    $"Your Notebooks:" + Environment.NewLine +
                    $"{String.Join("\n\n", EngineMaikaTI.loggedUser.Notebooks)}" + Environment.NewLine +
                    $"Your Taks:" + Environment.NewLine +
                    $"  {String.Join("\n", EngineMaikaTI.loggedUser.Tasks)}";
        }
    }
}
