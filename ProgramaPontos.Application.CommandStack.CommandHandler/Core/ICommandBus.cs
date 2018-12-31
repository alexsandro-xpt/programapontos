
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.Core
{
    public interface ICommandBus
    {

       Task<ICommandResponse> SendCommand<T>(T command) where T : ICommand;

      
        
    }
}
