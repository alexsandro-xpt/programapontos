using ProgramaPontos.Application.CommandStack.CommandHandler;

using ProgramaPontos.Domain.Services;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;


namespace ProgramaPontos.Infra.InMemory.CommandBus
{
    public class InMemoryCommandBus : ICommandBus
    {

        private Dictionary<Type, ICommandHandler<ICommand>> commandHandlerMap;

        public InMemoryCommandBus()
        {

            commandHandlerMap = new Dictionary<Type, ICommandHandler<ICommand>>();
            
            
        }

        public void RegisterHandler<THandler>(THandler handler) where THandler : ICommandHandler<ICommand>
        {
            commandHandlerMap.Add(handler.GetType().BaseType.GetGenericArguments().First(), handler);
        }

        public ICommandResponse SendCommand<T>(T command) where T : ICommand
        {

            var commandHandler = (ICommandHandler<ICommand>)commandHandlerMap[command.GetType()];
            return commandHandler.Handle(command);                        


        }

        
    }
}
