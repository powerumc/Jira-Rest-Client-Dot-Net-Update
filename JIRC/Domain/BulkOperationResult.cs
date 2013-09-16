using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JIRC.Domain
{
    public class BulkOperationResult<T>
    {
        public BulkOperationResult(IEnumerable<T> issues, IEnumerable<BulkOperationErrorResult> errors)
        {
            Issues = issues;
            Errors = errors;
        }

        public IEnumerable<T> Issues { get; set; }

        public IEnumerable<BulkOperationErrorResult> Errors { get; set; }
    }
}
