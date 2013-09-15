
namespace JIRC.Domain.Input
{
    public class ComponentInputWithProjectKey : ComponentInput
    {
        public ComponentInputWithProjectKey(string projectKey, ComponentInput componentInput)
            : base(componentInput)
        {
            ProjectKey = projectKey;
        }

        public string ProjectKey { get; set; }
    }
}
