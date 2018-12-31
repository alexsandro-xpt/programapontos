using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.Core
{
    public interface ICommand 
    {
        DateTime DateTime { get; }
    }
}
