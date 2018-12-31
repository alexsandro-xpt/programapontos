using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.Core
{
    public abstract class Command : ICommand
    {
        public DateTime DateTime { get; }

        public Command()
        {
            DateTime = DateTime.Now;
        }
    }
}
