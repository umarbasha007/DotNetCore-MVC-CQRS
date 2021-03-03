using ExamPortal.Contracts.Queries;
using System;
using System.Collections.Generic;

namespace ExamPortal.Infrastructure.Handlers
{
    /// <summary>
    /// Defines a query handler.
    /// </summary>
    /// <typeparam name="TQuery">Type of query to handle.</typeparam>
    /// <typeparam name="TResult">Result to expect from the query.</typeparam>
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Handle the query. This means perform a query and return the expected result.
        /// </summary>
        /// <param name="query">Query to handle.</param>
        /// <returns>Result of the query.</returns>
        IEnumerable<TResult> Handle(TQuery query);
    }
}
