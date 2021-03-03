using System;
using System.Collections.Generic;
using StructureMap;
using System.Diagnostics;
using System.Security.Principal;
using ExamPortal.Contracts.Queries;
using StructureMap.Attributes;
using ExamPortal.Data.Common;

namespace ExamPortal.Infrastructure.Handlers
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
      where TQuery : IQuery<TResult>
    {
        public QueryHandlerBase()
        {

        }
        [SetterProperty]
        public IQueryContext Context { get; set; }
        public abstract IEnumerable<TResult> Handle(TQuery command);


    }
}
