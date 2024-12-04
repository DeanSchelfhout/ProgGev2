namespace GymTestDL.Models
{
    public class ProgramMemberEF
    {
        public string ProgramCode { get; set; }
        public int MemberId { get; set; }

        // Navigation Properties
        public ProgramModelEF Program { get; set; }
        public MemberEF Member { get; set; }
    }
}
