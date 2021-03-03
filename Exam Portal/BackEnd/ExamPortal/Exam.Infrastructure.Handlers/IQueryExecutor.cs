using ExamPortal.Contracts.Queries;
using System;
using System.Collections.Generic;


namespace ExamPortal.Infrastructure.Handlers
{
    /// <summary>
    /// Defines the query executor.
    /// </summary>
    public interface IQueryExecutor
    {
        /// <summary>
        /// Execute the query and return a result. This will find a query
        /// handler and use that to execute the query.
        /// </summary>
        /// <typeparam name="TResult">Result type.</typeparam>
        /// <param name="query">Query to execute.</param>
        /// <returns>Query result.</returns>
        IEnumerable<TResult> ExecuteQuery<TResult>(IQuery<TResult> query);
    }
}
