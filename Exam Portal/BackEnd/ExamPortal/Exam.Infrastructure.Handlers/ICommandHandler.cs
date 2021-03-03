using ExamPortal.Contracts.Commands;
using System;

namespace ExamPortal.Infrastructure.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : CommandBase
    {
        void Handle(TCommand command);
    }
}
