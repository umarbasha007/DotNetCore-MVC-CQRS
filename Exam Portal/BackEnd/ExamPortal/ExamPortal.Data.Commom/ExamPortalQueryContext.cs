using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPortal.Data.Common
{
    public class ExamPortalQueryContext : IQueryContext
    {

        ExamPortalontext _objExamPortalontext;

        public ExamPortalQueryContext(ExamPortalontext objExamPortalontext)
        {
            _objExamPortalontext = objExamPortalontext;
        }
    }
}
