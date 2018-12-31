
using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.Extensions
{
    public static class CommandBusExtensions
    {
        public static async Task<Resultado> EnviarCommandoRetornaResultadoAsync(this ICommandBus commandBus, ICommand command)
        {
            var response = await commandBus.SendCommand(command);
            return new Resultado(response);
        }
    }
}
