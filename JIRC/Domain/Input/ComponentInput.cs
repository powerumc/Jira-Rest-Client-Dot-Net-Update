
namespace JIRC.Domain.Input
{
    public class ComponentInput
    {
        public ComponentInput()
        {
        }

        protected ComponentInput(ComponentInput componentInput)
        {
            Name = componentInput.Name;
            Description = componentInput.Description;
            LeadUserName = componentInput.LeadUserName;
            AssigneeType = componentInput.AssigneeType;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LeadUserName { get; set; }

        public AssigneeType AssigneeType { get; set; }
    }
}
