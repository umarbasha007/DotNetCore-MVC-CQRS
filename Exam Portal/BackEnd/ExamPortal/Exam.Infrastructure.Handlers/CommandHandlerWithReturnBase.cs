using System;
using ExamPortal.Contracts.Commands;
using ExamPortal.Data.Common;
using StructureMap.Attributes;
using System.Collections.Generic;

namespace ExamPortal.Infrastructure.Handlers
{
    public abstract class CommandHandlerWithReturnBase<TCommand> : ICommandHandlerWithReturn<TCommand> where TCommand : CommandBase
    {
        public CommandHandlerWithReturnBase()
        {
        }

        [SetterProperty]
        public ICommandContext Context { get; set; }
        public abstract Dictionary<string, object> Handle(TCommand command);


    }
}
