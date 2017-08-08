﻿using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    class AddTaskCommand : Command, ICommand
    {
        public AddTaskCommand()
            : base()
        {
        }

        public override string Execute()
        {
            string title = this.Parameters[0];
            string priorityStr = this.Parameters[1];
            string description = this.Parameters[2];

            ITask task = this.factory.CreateTask(title, priorityStr, description);
            EngineMaikaTI.loggedUser.AddTask(task);

            return Messages.TaskCreated(title);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Title: "));
            inputParameters.Add(this.ReadOneLine("Priority: "));
            string description=this.ReadOneLine("Description: ");

            description = CheckIfThereWasLostDescription(description);
            inputParameters.Add(description);

            EngineMaikaTI.lastDescription = description;
            this.Parameters = inputParameters;
        }

        private string CheckIfThereWasLostDescription(string description)
        {
            if (description == "last" && EngineMaikaTI.lastDescription != null)
            {
                return EngineMaikaTI.lastDescription;
            }
            return description;
        }
    }
}
