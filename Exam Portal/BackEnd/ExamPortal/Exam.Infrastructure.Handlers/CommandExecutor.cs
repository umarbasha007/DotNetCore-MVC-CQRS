using System;
using StructureMap;
using System.Diagnostics;
using System.Security.Principal;
using System.Collections.Generic;
using ExamPortal.Contracts.Commands;

namespace ExamPortal.Infrastructure.Handlers
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IContainer container;

        public CommandExecutor(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }



        [DebuggerStepThrough]
        public void ExecuteCommand(IPrincipal principal, CommandBase command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            try
            {
                var handler = container.GetInstance(handlerType);

                // invoke the Handle method
                var handleMethod = handlerType.GetMethod("Handle");
                handleMethod.Invoke(handler, new[] { (object)command });
            }
            catch (StructureMapException ex)
            {
                var message = string.Format("No handler found for {0}. Implement ICommandHandler<{0}>", command.GetType().Name);
                throw new ApplicationException(message, ex);
            }
        }

        [DebuggerStepThrough]
        public Dictionary<string, object> ExecuteCommandWithReturn(IPrincipal principal, CommandBase command)
        {
            var handlerType = typeof(ICommandHandlerWithReturn<>).MakeGenericType(command.GetType());
            try
            {
                var handler = container.GetInstance(handlerType);

                // invoke the Handle method
                var handleMethod = handlerType.GetMethod("Handle");
                var result = (Dictionary<string, object>)handleMethod.Invoke(handler, new[] { (object)command });
                return result;
            }
            catch (StructureMapException ex)
            {
                var message = string.Format("No handler found for {0}. Implement ICommandHandler<{0}>", command.GetType().Name);
                throw new ApplicationException(message, ex);
            }
        }

        [DebuggerStepThrough]
        public Dictionary<string, object> ExecutePutCommandWithReturn(IPrincipal principal, CommandBase command, string id)
        {
            var handlerType = typeof(ICommandHandlerWithReturn<>).MakeGenericType(command.GetType());
            try
            {
                var handler = container.GetInstance(handlerType);

                // invoke the Handle method
                var handleMethod = handlerType.GetMethod("Handle");
                var result = (Dictionary<string, object>)handleMethod.Invoke(handler, new[] { (object)command, id });
                return result;
            }
            catch (StructureMapException ex)
            {
                var message = string.Format("No handler found for {0} and {1}. Implement ICommandHandler<{0}>", command.GetType().Name, id);
                throw new ApplicationException(message, ex);
            }
        }
    }
}
