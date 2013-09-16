using System.Collections.Generic;

namespace JIRC.Domain.Util
{
    public class ErrorCollection
    {
        public ErrorCollection(int status, IEnumerable<string> errorMessages, IDictionary<string, string> errors)
        {
            Status = status;
            ErrorMessages = errorMessages;
            Errors = errors;
        }

        public int Status { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }

        public IDictionary<string, string> Errors { get; set; }
    }
}
