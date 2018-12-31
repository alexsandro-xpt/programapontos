using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Domain.Core.Exceptions
{
    public class ConsistencyException : Exception
    {
        public ConsistencyException(Guid aggregateId) : base($"Erro de consistência para o aggregate {aggregateId}")
        {

        }
    }
}
