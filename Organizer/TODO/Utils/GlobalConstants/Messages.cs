
using System;
using TODO.Engine;

namespace TODO.Utils.GlobalConstants
{
    public static class Messages
    {
        public static string NotebookCreated(string notebookName)
        {
            return $"Notebook \"{notebookName}\" added successfully !";
        }

        public static string NoteCreated(string title)
        {
            return $"Note {title} added successfully !";
        }

        internal static string LoggedOut()
        {
            throw new NotImplementedException();
        }

        public static string LongTermTaskCreated(string title)
        {
            return $"Long term task {title} has been added";
        }

        public static string SubTaskCreated(string title)
        {
            return $"Sub task {title} added to {EngineMaikaTI.currentLongTermTask.Title}";
        }

        public static string SuccessfulyLogged()
        {
            return "Successfuly logged!";
        }

        public static string WrongCredentials()
        {
            return "Wrong credentials!";
        }

        public static string UserCreated(string username)
        {
            return $"User {username} created successfuly!";
        }

        public static string InvalidTaskName()
        {
            return "Task name is invalid";
        }

        public static string WrongPriority()
        {
            return "Wrong priority!";
        }

        public static string TaskRemoved(string taskName)
        {
            return $"{taskName} was removed successfuly";
        }

        public static string NoteAddedToFavourites()
        {
            return "Note added to favourites";
        }

        public static string WrongTaskName()
        {
            return "Wrong task name!";
        }

        internal static string NoSubtaskFound()
        {
            return "No subtask found";
        }


        internal static string NoLongTermTaskFound()
        {
            return "No long term task found";
        }

        internal static string AddedReminderToTask(string taskName)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            
            return $"Added reminder to {taskName}";
        }

        public static string TaskCreated(string title)
        {
            return $"Added tast {title} successfully !";
        }

        public static string NotebookSwitched(string newNotebookName)
        {
            return $"Successfully switched to {newNotebookName} notebook";
        }

        public static string WrongNotebookName()
        {
            return $"You don't have a notebook with this name";
        }

        public static string MustCreateANotebook()
        {
            return "You must create a notebook first";
        }

        public static string NotebookAddedToFavourites()
        {
            return "Notebook successfully added to Favourites";
        }

        public static string WrongNoteTitle()
        {
            return "Wrong Note Title!";
        }

        public static string HistoryCleared()
        {
            return $"History Cleared";
        }
    }
}
