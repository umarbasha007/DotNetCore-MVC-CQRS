using System;
using System.Threading;
using StructureMap.Attributes;
using System.Collections.Generic;
using ExamPortal.Contracts.Commands;
using ExamPortal.Contracts.Queries;

namespace ExamPortal.Infrastructure.Handlers
{
    public interface ITaskHandler
    {
    }

    public class TaskHandlerBase : ITaskHandler
    {
        public TaskHandlerBase()
        {
        }

        [SetterProperty]
        public ICommandExecutor CommandExecuter { get; set; }

        [SetterProperty]
        public IQueryExecutor QueryExecutor { get; set; }
        /// <summary>
        /// Execute command to modify database.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <exception cref="ArgumentNullException">If command is null.</exception>
       // [DebuggerStepThrough]
        public void ExecuteCommand(CommandBase command)
        {
            if ((System.Object)command == null) throw new ArgumentNullException("command");
            CommandExecuter.ExecuteCommand(Thread.CurrentPrincipal, command);
        }

        //public object ExecuteQuery<T>(T userInfoQuery)
        //{
        //    throw new NotImplementedException();
        //}

        public Dictionary<string, object> ExecuteCommandWithReturn(CommandBase command)
        {
            if ((System.Object)command == null) throw new ArgumentNullException("command");
            return CommandExecuter.ExecuteCommandWithReturn(Thread.CurrentPrincipal, command);
        }

        public Dictionary<string, object> ExecutePutCommandWithReturn(CommandBase command, string id)
        {
            if ((System.Object)command == null) throw new ArgumentNullException("command");
            return CommandExecuter.ExecutePutCommandWithReturn(Thread.CurrentPrincipal, command, id);
        }
        /// <summary>
        /// Executes a query and returns the result.
        /// </summary>
        /// <typeparam name="TResult">Result type.</typeparam>
        /// <param name="query">Query to execute.</param>
        /// <returns>Result of query.</returns>
        //[DebuggerStepThrough]
        public IEnumerable<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException("query");
            return QueryExecutor.ExecuteQuery(query);
        }


    }
}
