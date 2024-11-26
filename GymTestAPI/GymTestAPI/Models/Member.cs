namespace GymTestAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public List<string> Interests { get; set; }
        public string MemberType { get; set; }

        public ICollection<Reservation> Reservations { get; set; } 
        public ICollection<ProgramMember> ProgramMembers { get; set; }  
        public ICollection<CyclingSession> CyclingSessions { get; set; }  
        public ICollection<RunningSessionMain> RunningSessionsMain { get; set; }
    }
}
