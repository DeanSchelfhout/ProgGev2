namespace GymTestAPI.Models
{
    public class ProgramMember
    {
        public string ProgramCode { get; set; }
        public int MemberId { get; set; }

        public ProgramModel ProgramModel { get; set; }
        public Member Member { get; set; }
    }
}
