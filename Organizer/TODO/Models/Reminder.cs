using System;
using System.Collections.Generic;
using System.Threading;
using TODO.Contracts;

namespace TODO.Models
{
    public class Reminder : IReminder, ISaveable
    {
        private DateTime momentToRemind;

        public Reminder(DateTime momentToRemind)
        {
            this.MomentToRemind = momentToRemind;
        }

        public DateTime MomentToRemind
        {
            get
            {
                return this.momentToRemind;
            }
            private set
            {
                this.momentToRemind = value;
            }
        }

        public void Remind()
        {
        }

        public string FormatUserInfoForDB()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{this.MomentToRemind}";
        }
    }
}
