using System;
using ExamPortal.Contracts.Commands;
using ExamPortal.Data.Common;
using StructureMap.Attributes;
using System.Collections.Generic;


namespace ExamPortal.Infrastructure.Handlers
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : CommandBase
    {
        public CommandHandlerBase()
        {
        }

        [SetterProperty]
        public ICommandContext Context { get; set; }
        public abstract void Handle(TCommand command);
    }
}
