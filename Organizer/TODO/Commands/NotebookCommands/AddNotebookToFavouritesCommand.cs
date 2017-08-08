using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;

namespace TODO.Commands
{
    class AddNotebookToFavouritesCommand : Command, ICommand
    {
        public override string Execute()
        {
            string notebookTitle = base.Parameters[0];

            if (EngineMaikaTI.loggedUser.Notebooks.All(x => x.Name != notebookTitle))
            {
                return $"Wrong Notebook Title !";
            }
                
            EngineMaikaTI.loggedUser.Notebooks.First(x => x.Name == notebookTitle).IsFavourite = true;
            return $"Notebook successfully added to Favourites";
        }

        public override void TakeInput()
        {
            List<string> parameters = new List<string>();
            parameters.Add(ReadOneLine("Notebook Title: "));
            base.Parameters = parameters;
        }
    }
}
