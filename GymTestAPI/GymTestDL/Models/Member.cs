namespace GymTestAPI.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Interests { get; set; }

        // Navigation Properties
        public ICollection<CyclingSession> CyclingSessions { get; set; }
        public ICollection<RunningSessionMain> RunningSessions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<ProgramMember> ProgramMembers { get; set; }
    }

}
