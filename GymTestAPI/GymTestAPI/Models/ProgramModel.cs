namespace GymTestAPI.Models
{
    public class ProgramModel
    {
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

        public ICollection<ProgramMember> ProgramMembers { get; set; }
    }
}
