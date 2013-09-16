using JIRC.Domain.Util;

namespace JIRC.Domain
{
    public class BulkOperationErrorResult
    {
        public BulkOperationErrorResult(ErrorCollection errors, int failedElementNumber)
        {
            Errors = errors;
            FailedElementNumber = failedElementNumber;
        }

        public ErrorCollection Errors { get; set; }

        public int FailedElementNumber { get; set; }
    }
}
