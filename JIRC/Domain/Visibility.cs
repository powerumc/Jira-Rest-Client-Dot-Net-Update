namespace JIRC.Domain
{
    public class Visibility
    {
        public Visibility(VisibilityType type, string value)
        {
            Type = type;
            Value = value;
        }

        public VisibilityType Type { get; set; }

        public string Value { get; set; }

        public enum VisibilityType
        {
            Role,
            Group
        }
    }
}
