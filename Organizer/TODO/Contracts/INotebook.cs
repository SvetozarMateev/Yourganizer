using System.Collections.Generic;
using TODO.Models;

namespace TODO.Contracts
{
    public interface INotebook : ISaveable
    {
        ICollection<INote> Notes { get; }
       // IUser User { get; }
        bool IsFavourite { get; set; }
        string Name { get; }

        void AddNote(INote note);
        void DeleteNote(Note note);
        void EditNote(Note note);
        void Sort();
    }
}
