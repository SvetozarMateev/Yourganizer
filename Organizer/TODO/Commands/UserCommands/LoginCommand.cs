using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Engine;

namespace TODO.Commands
{
    public class LoginCommand : Command, ICommand
    {
        private List<string> usernamesAndPasswords = Loader.LoadUsernamesAndPasswords();

        public LoginCommand()
            : base()
        {
        }

        public override string Execute()
        {
            string username = base.Parameters[0];
            string password = base.Parameters[1];

            if (CheckCredentials(username, password))
            {
                SetCurrentParameters(username,password);
               
                return "Successfully logged !";
            }

            return "Wrong Credentials";
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Username: "));
            inputParameters.Add(this.ReadOneLine("Password: "));
            this.Parameters = inputParameters;
        }

        private bool CheckCredentials(string inputUsername, string inputPassword)
        {
            foreach (var userAndPass in this.usernamesAndPasswords)
            {
                string username = userAndPass.Split()[0];
                string password = userAndPass.Split()[1];
                if (username == inputUsername && password == inputPassword)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetCurrentParameters(string username, string password)
        {
            EngineMaikaTI.loggedUser = Loader.LoadUser(username, password);

            if (EngineMaikaTI.loggedUser.Notebooks.Count > 0)
            {
                EngineMaikaTI.currentNotebook = EngineMaikaTI.loggedUser.Notebooks.First();
            }
            if (EngineMaikaTI.loggedUser.LongTermTasks.Count > 0)
            {
                EngineMaikaTI.currentLongTermTask = EngineMaikaTI.loggedUser.LongTermTasks.First();
            }
        }
    }
}
