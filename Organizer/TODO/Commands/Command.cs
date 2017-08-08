using System;
using System.Collections.Generic;
using TODO.Factories;
using TODO.Utils.Validator;

namespace TODO.Engine
{
    public abstract class Command : ICommand
    {
        protected List<string> parameters;
        protected OrganizerFactory factory;

        public Command()
        {           
            this.factory = new OrganizerFactory();
        }

        public List<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            protected set
            {
                Validator.ListCannotBeNullOrEmpty(value);
                
                this.parameters = value;
            }
        }

        public abstract string Execute();

        public abstract void TakeInput();

        protected virtual string ReadOneLine(string instruction)
        {
            Console.Write(instruction);
            return Console.ReadLine();
        }
    }
}
