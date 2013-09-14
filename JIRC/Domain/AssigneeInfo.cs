namespace JIRC.Domain
{
    public class AssigneeInfo
    {
        public BasicUser Assignee { get; set; }
        public AssigneeType AssigneeType { get; set; }
        public BasicUser RealAssignee { get; set; }
        public AssigneeType RealAssigneeType { get; set; }
        public bool AssigneeTypeValid { get; set; }
    }
}
