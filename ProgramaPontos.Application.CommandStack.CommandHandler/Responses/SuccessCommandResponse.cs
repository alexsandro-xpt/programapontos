using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.Responses
{
    public class SuccessCommandResponse : CommandResponse
    {
        public SuccessCommandResponse() : base(true, null) { }
    }
}
