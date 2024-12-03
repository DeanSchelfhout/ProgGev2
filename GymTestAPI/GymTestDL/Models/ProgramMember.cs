namespace GymTestAPI.Models
{
    public class ProgramMember
    {
        public string ProgramCode { get; set; }
        public int MemberId { get; set; }

        // Navigation Properties
        public ProgramModel Program { get; set; }
        public Member Member { get; set; }
    }
}
