using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.Responses
{
    public class CommandResponse : ICommandResponse
    {
        

        public CommandResponse(bool isValid, Exception exception)
        {
            IsValid = isValid;
            Exception = exception;
        }

        public bool IsValid { get; }
        public Exception Exception { get; }
    }
}
