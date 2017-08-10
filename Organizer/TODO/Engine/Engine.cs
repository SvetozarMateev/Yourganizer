using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Commands;
using TODO.Commands.TaskCommands;
using TODO.Contracts;
using TODO.Factories;
using TODO.Utils.GlobalConstants;

namespace TODO.Engine
{
    public class EngineMaikaTI : IEngine
    {
        private readonly IOrganizerFactory factory = new OrganizerFactory();
        public static IUser loggedUser;
        public static INotebook currentNotebook;
        public static ILongTermTask currentLongTermTask;
        public static string lastDescription;

        public void Start()
        {

            while (true)
            {

                try
                {
                    List<string> commands = this.ReadCommands();

                    if (commands[0].Equals("exit"))
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(commands?[0])) // checks if its null or if the first element is nullOrEmpty
                    {
                        continue;
                    }

                    this.ProcessCommands(commands);
                    if (loggedUser != null)
                    {
                        Saver.CreateUserFile(loggedUser);
                    }
                    //this.PrintReports(commandResult);

                }
                catch (Exception ex)
                {
                    Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommands(List<string> commands)
        {
            string commandType = commands[0];
            ICommand command = null;
            string commandResult = String.Empty;

            switch (commandType )
            {
                case "register":
                case "registeruser":
                    command = new RegisterCommand();
                    break;
                case "login":
                case "log":
                    command = new LoginCommand();
                    break;
                case "logout":
                    command = new LogOutCommand();
                    break;
                case "addnotebook":
                    command = new AddNotebookCommand();
                    break;
                case "addnote":                   
                    if (loggedUser.Notebooks.Count == 0)
                    {
                        throw new ArgumentException(Messages.MustCreateANotebook());
                    }
                    command = new AddNoteCommand();
                    break;
                case "switchnotebook":
                    command = new SwitchNotebookCommand();
                    break;
                case "addtask":
                    command = new AddTaskCommand();
                    break;
                case "addlongtermtask":
                    command = new AddLongTermTaskCommand();
                    break;
                case "addsubtask":
                    command = new AddSubtaskCommand();
                    break;
                case "addremindertotask":
                    command = new AddReminderToTaskCommand();
                    currentForeground = Console.ForegroundColor;
                    colorChange = true;
                    break;
                case "addnotetofavourites":
                    command = new AddNoteToFavouritesCommand();
                    break;
                case "addnotebooktofavourites":
                    command = new AddNotebookToFavouritesCommand();
                    break;
                case "list":
                    command = new ListCommand();
                    break;
                case "switchlongtertask":
                    command = new SwitchLongTermTaskCommand();
                    break;
                case "deletetask":
                    command = new DeleteTaskCommand();
                    break;
                case "deletesubtask":
                    command = new DeleteSubTaskCommand();
                    break;
                case "clearhistory":
                    command = new ClearHistoryCommand();
                    break;
                default:
                    break;
            }

            command.TakeInput();
            commandResult = command.Execute();

            Writer.WriteLine(commandResult);
        }

        private List<string> ReadCommands()
        {
            List<string> commands = Console.ReadLine()
                .Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            bool isUserCreatable = loggedUser == null && commands[0] != "login" && commands[0] != "register";


            if (isUserCreatable)
            {
                Writer.NoUserLogged();
                ReadCommands();
            }
            return commands;
        }
    }
}
