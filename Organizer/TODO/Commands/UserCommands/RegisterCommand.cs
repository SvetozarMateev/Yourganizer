using System;
using System.Collections.Generic;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class RegisterCommand : Command, ICommand
    {
        public RegisterCommand()
            : base()
        {

        }

        public override string Execute()
        {
            string username = base.Parameters[0];
            string password = base.Parameters[1];
            EngineMaikaTI.loggedUser = base.Factory.CreateUser(username, password);
            Saver.SaveUsernamesAndPasswords(username, password);

           return Messages.UserCreated(username); 
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Username: "));
            inputParameters.Add(this.ReadOneLine("Password: "));
            this.Parameters = inputParameters;
        }
    }
}
