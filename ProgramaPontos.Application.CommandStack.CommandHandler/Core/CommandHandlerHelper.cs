using ProgramaPontos.Application.CommandStack.Responses;


using System;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.Core
{
    public class CommandHandlerHelper
    {


        public static Task<ICommandResponse> ExecuteToResponse(Action action)
        {
            return Task.Run<ICommandResponse>(() =>
           {
               try
               {
                   action.Invoke();
                   return new SuccessCommandResponse();
               }
               catch (Exception ex)
               {
                   return new ErrorCommandResponse(ex);
               }
           });
        }


    }
}
