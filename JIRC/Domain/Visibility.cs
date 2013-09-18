namespace JIRC.Domain
{
    public class Visibility
    {
        public Visibility(VisibilityType type, string value)
        {
            Type = type;
            Value = value;
        }

        public VisibilityType Type { get; private set; }

        public string Value { get; private set; }

        public static Visibility Role(string value)
        {
            return new Visibility(VisibilityType.Role, value);
        }

        public static Visibility Group(string value)
        {
            return new Visibility(VisibilityType.Group, value);
        }

        public enum VisibilityType
        {
            Role,
            Group
        }
    }
}
