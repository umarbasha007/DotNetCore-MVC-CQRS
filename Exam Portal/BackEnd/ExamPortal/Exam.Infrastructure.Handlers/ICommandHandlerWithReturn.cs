using ExamPortal.Contracts.Commands;
using System;
using System.Collections.Generic;

namespace ExamPortal.Infrastructure.Handlers
{
    public interface ICommandHandlerWithReturn<in TCommand> where TCommand : CommandBase
    {
        Dictionary<string, object> Handle(TCommand command);


    }
}
