using System;
using StructureMap;
using System.Diagnostics;
using System.Collections.Generic;
using ExamPortal.Contracts.Queries;

namespace ExamPortal.Infrastructure.Handlers
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IContainer container;

        public QueryExecutor(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }

        [DebuggerStepThrough]
        public IEnumerable<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException("query");

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            var handler = container.GetInstance(handlerType);

            var handleMethod = handlerType.GetMethod("Handle");
            var result = (IEnumerable<TResult>)handleMethod.Invoke(handler, new[] { (object)query });
            return result;
        }
    }
}
