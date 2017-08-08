using System;

namespace TODO.Contracts
{
    public interface INote: ISaveable
    {
        string Title { get; }
        string Content { get; }
        DateTime DateOfCreation { get; }
        bool IsFavourite { get; set; }


    }
}
