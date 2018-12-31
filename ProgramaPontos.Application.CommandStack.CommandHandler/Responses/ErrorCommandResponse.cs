using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.Responses
{
    public class ErrorCommandResponse : CommandResponse
    {
        public ErrorCommandResponse(Exception exception) : base(false, exception)
        {
        }

    }
}
