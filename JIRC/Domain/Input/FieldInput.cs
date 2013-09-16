
namespace JIRC.Domain.Input
{
    public class FieldInput
    {
        public FieldInput(string id, object value)
        {
            Id = id;
            Value = value;
        }

        public FieldInput(IssueFieldId field, object value)
        {
            Id = field.ToRestString();
            Value = value;
        }

        public string Id { get; set; }

        public object Value { get; set; }
    }
}
