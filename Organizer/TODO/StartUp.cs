using System;
using System.Collections.Generic;
using TODO.Models;
using TODO.Engine;
using System.Threading;
using System.Linq;
using TODO.Contracts;

namespace TODO
{
    public class StartUp
    {
        private static List<IReminder> momentsToRemind = new List<IReminder>();

        public static void Main()
        {
            EngineMaikaTI engine = new EngineMaikaTI();
            engine.Start();
        }

    }
}