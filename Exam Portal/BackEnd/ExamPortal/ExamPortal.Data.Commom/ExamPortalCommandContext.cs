using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPortal.Data.Common
{
    public class ExamPortalCommandContext : ICommandContext
    {
        ExamPortalContext _objDbContext;
        public ExamPortalCommandContext(ExamPortalContext objDbContext)
        {
            _objDbContext = objDbContext;
        }
    }
}
