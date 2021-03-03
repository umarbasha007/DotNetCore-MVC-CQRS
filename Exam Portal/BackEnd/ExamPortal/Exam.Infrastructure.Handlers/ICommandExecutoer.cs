using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using ExamPortal.Contracts.Commands;

namespace ExamPortal.Infrastructure.Handlers
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(IPrincipal principal, CommandBase command);
        Dictionary<string, object> ExecuteCommandWithReturn(IPrincipal principal, CommandBase command);

        Dictionary<string, object> ExecutePutCommandWithReturn(IPrincipal principal, CommandBase command, string id);
    }
}
