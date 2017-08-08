using System;
using System.Collections.Generic;

namespace TODO.Contracts
{
    public interface IReminder : ISaveable
    {
        DateTime MomentToRemind { get; }
        void Remind();
    }
}
