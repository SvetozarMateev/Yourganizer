using System;
using System.Collections.Generic;
using System.Linq;
using TODO.Contracts;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class AddNoteCommand : Command, ICommand
    {
        public AddNoteCommand()
            : base()
        {

        }

        public override string Execute()
        {
            string title = base.Parameters[0];
            string content = base.Parameters[1];
            INote note = this.factory.CreateNote(title,content);
            EngineMaikaTI.currentNotebook.AddNote(note);

            return Messages.NoteCreated(title);
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Title: "));
            
            string content = this.ReadOneLine("Content: ");
            content = CheckIfThereWasLostDescription(content);
            inputParameters.Add(content);
            EngineMaikaTI.lastDescription = content;
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
