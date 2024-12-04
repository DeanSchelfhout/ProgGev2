namespace GymTestBL.Models
{
    public class Member
    {
        public enum memberType
        {
            Bronze,
            Silver,
            Gold
        }
        public Member(int memberId, string firstName, string lastName, string email, string address, DateTime birthday, List<string> interests, ICollection<CyclingSession> cyclingSessions, ICollection<RunningSessionMain> runningSessions, ICollection<Reservation> reservations, ICollection<ProgramModel> programs, memberType memberType)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            CyclingSessions = cyclingSessions;
            RunningSessions = runningSessions;
            Reservations = reservations;
            Programs = programs;
            MemberType = memberType;
        }

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public memberType MemberType { get; set; }

        // Navigation Properties
        public ICollection<CyclingSession> CyclingSessions { get; set; }
        public ICollection<RunningSessionMain> RunningSessions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<ProgramModel> Programs { get; set; }
    }

}
