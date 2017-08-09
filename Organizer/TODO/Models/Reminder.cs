using System;
using System.Threading;
using TODO.Contracts;

namespace TODO.Models
{
    public class Reminder : IReminder, ISaveable
    {
        private TimeSpan momentToRemind;

        public Reminder(TimeSpan momentToRemind)
        {
            this.MomentToRemind = momentToRemind;
        }

        public TimeSpan MomentToRemind
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

        public void Remind(object state)
        {
            Timer timer = state as Timer;
            timer.Change(this.MomentToRemind, new TimeSpan(0,0,2));
            Writer.RemindText("GG WP");
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
