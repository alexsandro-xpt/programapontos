using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator mediator;

        public CommandBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<ICommandResponse> SendCommand<T>(T command) where T : ICommand
        {
            return mediator.Send((IRequest<ICommandResponse>)command);
            
        }
    }
}
