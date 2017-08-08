using System;
using System.Collections.Generic;
using TODO.Models;
using TODO.Engine;

namespace TODO
{
    public class StartUp
    {
        public static void Main()
        {
            //Note note = new Note("Homework", "I have to do my homework by the end of the week");
            //Notebook notebook1 = new Notebook("First Notebook");

            EngineMaikaTI engine = new EngineMaikaTI();
            engine.Start();
        }
    }
}