using System;
using System.Collections.Generic;
using TODO.Engine;

namespace TODO.Commands
{
    public class LogOutCommand : Command, ICommand
    {
        public LogOutCommand()
            : base()
        {
        }

        public override string Execute()
        {
            EngineMaikaTI.loggedUser = null;
            return $"Successfully logged Out";
        }

        public override void TakeInput()
        {           
        }
    }
}
