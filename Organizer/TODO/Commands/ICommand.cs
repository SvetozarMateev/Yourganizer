using System.Collections.Generic;

namespace TODO.Engine
{
    public interface ICommand
    {
        List<string> Parameters { get; }

        string Execute();
        void TakeInput();
    }
}
